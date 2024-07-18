#!/bin/bash

# Variables
resourceGroupName="anup-rgTemplate"
deploymentName="anupazstorage12" # Unique deployment name using timestamp
templateFile="azurestoragetemplate.json"
location="westus2" # Specify your desired location
storageName="anupazurestoreg11"
storageAccountType="Standard_LRS"

# Check if the resource group exists
rgExists=$(az group exists --name $resourceGroupName)

# Create the resource group if it does not exist
if [ "$rgExists" = "false" ]; then
    echo "Resource group $resourceGroupName does not exist. Creating..."
    az group create --name $resourceGroupName --location $location
    if [ $? -ne 0 ]; then
        echo "Failed to create resource group $resourceGroupName."
        exit 1
    fi
else
    echo "Resource group $resourceGroupName already exists."
fi

# Create the deployment
echo "Creating deployment $deploymentName..."
deploymentOutput=$(az deployment group create \
    --name $deploymentName \
    --resource-group $resourceGroupName \
    --template-file $templateFile \
    --parameters storageName=$storageName storageAccountType=$storageAccountType \
    --output json)

# Check if the deployment was successful
if [ $? -ne 0 ]; then
    echo "Deployment $deploymentName failed."
    echo "Error details: $deploymentOutput"
    exit 1
else
    echo "Deployment $deploymentName succeeded."
fi

# Check the status of the deployment
echo "Checking the status of the deployment..."
statusOutput=$(az deployment group show --name $deploymentName --resource-group $resourceGroupName --output json)

# Output the status of the deployment
echo "Deployment status:"
echo $statusOutput | jq .properties.provisioningState

# Check if the deployment is successful
provisioningState=$(echo $statusOutput | jq -r .properties.provisioningState)
if [ "$provisioningState" != "Succeeded" ]; then
    echo "Deployment $deploymentName did not succeed. Current state: $provisioningState"
    exit 1
else
    echo "Deployment $deploymentName succeeded. Current state: $provisioningState"
fi
