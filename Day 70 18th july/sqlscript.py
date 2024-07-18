import subprocess
import getpass
import os

def run_command(command):
    process = subprocess.Popen(command, shell=True, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    out, err = process.communicate()
    if process.returncode != 0:
        print(f"Error: {err.decode('utf-8')}")
    else:
        print(out.decode('utf-8'))

def create_resource_group(resource_group_name, location):
    command = f"az group create --name {resource_group_name} --location {location}"
    run_command(command)

def deploy_template(resource_group_name, template_path, admin_user, admin_password):
    command = (f"az deployment group create --resource-group {resource_group_name} "
               f"--template-file {template_path} --parameters administratorLogin={admin_user} "
               f"administratorLoginPassword={admin_password}")
    run_command(command)

def delete_resource_group(resource_group_name):
    command = f"az group delete --name {resource_group_name} --yes --no-wait"
    run_command(command)

def main():
    template_path = os.path.join(os.path.dirname(__file__), 'azsqltemplate.json')

    while True:
        print("\nAzure Resource Manager")
        print("1. Create Resource Group")
        print("2. Deploy Template")
        print("3. Delete Resource Group")
        print("4. Exit")

        choice = input("Enter your choice: ")

        if choice == '1':
            project_name = input("Enter a project name for generating resource names: ")
            location = input("Enter an Azure location (e.g., centralus): ")
            resource_group_name = f"{project_name}rg"
            create_resource_group(resource_group_name, location)
        elif choice == '2':
            resource_group_name = input("Enter the Resource Group name: ")
            admin_user = input("Enter the SQL server administrator username: ")
            admin_password = input("Enter the SQL Server administrator password: ")
            deploy_template(resource_group_name, template_path, admin_user, admin_password)
        elif choice == '3':
            resource_group_name = input("Enter the Resource Group name to delete: ")
            delete_resource_group(resource_group_name)
        elif choice == '4':
            print("Exiting...")
            break
        else:
            print("Invalid choice. Please try again.")

if __name__ == "__main__":
    main()
