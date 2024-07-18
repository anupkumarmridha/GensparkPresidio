#!/bin/bash

# Function to print a message with a timestamp
print_message() {
    local message="$1"
    echo "[$(date +'%Y-%m-%d %H:%M:%S')] $message"
}

# Function to list all resource groups, optionally filtered by prefix
list_resource_groups() {
    echo -n "Enter a prefix to filter by (leave empty to list all): "
    read prefix

    print_message "Listing all resource groups..."

    if [ -z "$prefix" ]; then
        az group list --query "sort_by([].{name:name, location:location, provisioningState:properties.provisioningState}, &name)" --output table
    else
        az group list --query "[?contains(name, '$prefix')].{name:name, location:location, provisioningState:properties.provisioningState} | sort_by(@, &name)" --output table
    fi
}

# Function to check if a resource group exists
check_resource_group_exists() {
    local resource_group_name="$1"
    if az group show --name "$resource_group_name" > /dev/null 2>&1; then
        return 0 # Resource group exists
    else
        return 1 # Resource group does not exist
    fi
}

# Function to create a resource group
create_resource_group() {
    echo -n "Enter a project name for generating resource names: "
    read project_name
    echo -n "Enter an Azure location (e.g., centralus): "
    read location
    resource_group_name="${project_name}-rg"
    
    if check_resource_group_exists "$resource_group_name"; then
        print_message "Resource group '$resource_group_name' already exists."
    else
        print_message "Creating resource group '$resource_group_name' in location '$location'..."
        if az group create --name "$resource_group_name" --location "$location"; then
            print_message "Resource group '$resource_group_name' created successfully."
        else
            print_message "Failed to create resource group '$resource_group_name'."
        fi
    fi
}

# Function to ensure a resource group exists and create if not
ensure_resource_group_exists() {
    local resource_group_name="$1"
    local location="$2"
    
    print_message "Checking if resource group '$resource_group_name' exists..."
    if check_resource_group_exists "$resource_group_name"; then
        print_message "Resource group '$resource_group_name' already exists."
    else
        print_message "Resource group '$resource_group_name' does not exist. Creating it..."
        if az group create --name "$resource_group_name" --location "$location"; then
            print_message "Resource group '$resource_group_name' created successfully."
        else
            print_message "Failed to create resource group '$resource_group_name'."
            return 1
        fi
    fi
}

# Function to deploy the template
deploy_template() {
    template_path="$(dirname "$0")/azsqltemplate.json"
    echo -n "Enter the Resource Group name: "
    read resource_group_name
    echo -n "Enter the Azure location (e.g., centralus): "
    read location
    ensure_resource_group_exists "$resource_group_name" "$location" || return
    
    echo -n "Enter the SQL server administrator username: "
    read admin_user
    echo -n "Enter the SQL Server administrator password (must be at least 8 characters long, include uppercase, lowercase, numbers, and special characters): "
    read -s admin_password
    echo

    print_message "Deploying template to resource group '$resource_group_name'..."
    deployment_result=$(az deployment group create --resource-group "$resource_group_name" \
                                  --template-file "$template_path" \
                                  --parameters administratorLogin="$admin_user" \
                                               administratorLoginPassword="$admin_password" \
                                  --output json)
    
    deployment_status=$(echo "$deployment_result" | jq -r '.properties.provisioningState')

    if [ "$deployment_status" == "Succeeded" ]; then
        print_message "Template deployed successfully to resource group '$resource_group_name'."
    else
        print_message "Failed to deploy template to resource group '$resource_group_name'."
        echo "$deployment_result" | jq -r '.properties.error'
    fi
}

# Function to delete a resource group
delete_resource_group() {
    echo -n "Enter the Resource Group name to delete: "
    read resource_group_name
    
    print_message "Deleting resource group '$resource_group_name'..."
    if az group delete --name "$resource_group_name" --yes --no-wait; then
        print_message "Resource group '$resource_group_name' deleted successfully."
    else
        print_message "Failed to delete resource group '$resource_group_name'."
    fi
}

# Main menu
while true; do
    echo
    echo "Azure Resource Manager"
    echo "1. List Resource Groups"
    echo "2. Create Resource Group"
    echo "3. Deploy Template"
    echo "4. Delete Resource Group"
    echo "5. Exit"
    echo -n "Enter your choice: "
    read choice

    case $choice in
        1)
            list_resource_groups
            ;;
        2)
            create_resource_group
            ;;
        3)
            deploy_template
            ;;
        4)
            delete_resource_group
            ;;
        5)
            print_message "Exiting..."
            break
            ;;
        *)
            echo "Invalid choice. Please try again."
            ;;
    esac
done
