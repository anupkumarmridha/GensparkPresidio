using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibery;
using System.Xml.Linq;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private static Employee loggedInEmployee=null;

        private readonly IEmployeeRequestBL employeeRequestBL;
        private readonly IAdminRequestBL adminEmployeeBL;
        public Program()
        {
           employeeRequestBL = new EmployeeRequestBL
           (new EmployeeRepository(new RequestTrackerContext()),
                    new RequestRepository(new RequestTrackerContext()),
                         new RequestSolutionRepository(new RequestTrackerContext()),
                                    new SolutionFeedbackRepository(new RequestTrackerContext()));

            adminEmployeeBL = new AdminRequestBL
            (new EmployeeRepository(new RequestTrackerContext()),
                       new RequestRepository(new RequestTrackerContext()),
                                  new RequestSolutionRepository(new RequestTrackerContext()));

        }

        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password, Id = username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Login(employee);
            if (result!=null)
            {
                loggedInEmployee = result;
                await Console.Out.WriteLineAsync("Login Success");
            }
            else
            {
                Console.Out.WriteLine("Invalid username or password");
            }
        }
        async Task GetLoginDeatils()
        {
            int id = await GetValidIntegerInput("Please enter Employee Id = ");
            string password = await GetValidStringInput("Please enter your password = ");
            await EmployeeLoginAsync(id, password);
        }

        async Task EmployeeRegisterAsync(string name, string role, string password)
        {
            Employee employee = new Employee() {Name = name, Role=role, Password = password};
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            var result = await employeeLoginBL.Register(employee);
            if (result != null)
            {
                loggedInEmployee = result;
                await Console.Out.WriteLineAsync("Registration Success");
            }
            else
            {
                await Console.Out.WriteLineAsync("Registration Failed");
            }
        }
        async Task GetRegisterDetails()
        {
            string name = await GetValidStringInput("Please enter Employee name = ");
            string role = await GetValidStringInput("Please enter Employee role = ");
            string password = await GetValidStringInput("Please enter your password = ");
            await EmployeeRegisterAsync(name,role,password);
        }
        async Task Logout()
        {
            loggedInEmployee = null;
        }

        async Task DisplayMainMenu()
        {
            await Console.Out.WriteLineAsync("1. Login");
            await Console.Out.WriteLineAsync("2. Register");
            await Console.Out.WriteLineAsync("3. Exit");
        }
        async Task MainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                await DisplayMainMenu();
                int choice = await GetUserChoice(1, 3);
                switch (choice)
                {
                    case 1:
                        await GetLoginDeatils();
                        if(loggedInEmployee != null)
                        {
                            await EmployeeMenu();
                        }
                        break;
                    case 2:
                        await GetRegisterDetails();
                        if (loggedInEmployee != null)
                        {
                            await EmployeeMenu();
                        }
                        break;
                    case 3:
                        await Logout();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        async Task DisplayAdminMenu()
        {
            await Console.Out.WriteLineAsync("5. Add Solution to Request");
            await Console.Out.WriteLineAsync("6. Close Request");
            await Console.Out.WriteLineAsync("7. Show all requests");
            await Console.Out.WriteLineAsync("8. Display all Open Request");
            await Console.Out.WriteLineAsync("9. Display all Close Request");
            await Console.Out.WriteLineAsync("10. Display all Solution Of a Request");

        }
        async Task EmployeeSolutionMenu()
        { 
            await Console.Out.WriteLineAsync("1. Reply to Request Solution");
            await Console.Out.WriteLineAsync("2. Accept Solution");
            await Console.Out.WriteLineAsync("0. Exit");
        }
        async Task DisplayEmployeeMenu()
        {

            await Console.Out.WriteLineAsync(loggedInEmployee.ToString());
            await Console.Out.WriteLineAsync("0. Exit");
            await Console.Out.WriteLineAsync("1. Add Request");
            await Console.Out.WriteLineAsync("2. View All Request");
            await Console.Out.WriteLineAsync("3. View All Request By Status");
            await Console.Out.WriteLineAsync("4. View Request Solution");
           
            if(loggedInEmployee != null && loggedInEmployee.Role == "Admin")
            {
                await DisplayAdminMenu();
            }
        }

        async Task EmployeeMenu()
        {
            bool exit = false;
            while (!exit)
            {
                await DisplayEmployeeMenu();
                int minChoice = 0;
                int maxChoice = loggedInEmployee != null && loggedInEmployee.Role == "Admin" ? 10 : 5;

                int choice = await GetUserChoice(minChoice, maxChoice);

                switch (choice)
                {
                    case 1:
                        await AddRequest();
                        break;
                    case 2:
                        await ViewAllRequest();
                        break;
                    case 3:
                        await ViewAllRequestByStatus();
                        break;
                    case 4:
                        await ViewRequestSolution();
                        break;

                    case 5:
                        await AddRequestSolutionByAdmin();
                        break;

                    case 6:
                        await CloseRequestByAdmin();
                        break;
                    case 7:
                        await GetAllRequestsByAdmin();
                        break; 
                    
                    case 8:
                        await GetAllOpenRequestsByAdmin();
                        break;
                    
                    case 9:
                        await GetAllClosedRequestsByAdmin();
                        break;
                    
                    case 10:
                        await GetAllSolutionOfARequest();
                        break;

                    case 0:
                        await Logout();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        private async Task AddRequest()
        {
            string requestMessage = await GetValidStringInput("Enter your request message: ");
            await Console.Out.WriteLineAsync(loggedInEmployee.ToString());
            var result = await employeeRequestBL.AddRequest(loggedInEmployee.Id, requestMessage);
            if (result != null)
            {
                await Console.Out.WriteLineAsync("Request added successfully");
                await Console.Out.WriteLineAsync(result.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Request failed");
            }
        }
        private async Task ViewAllRequest()
        {
           var employeeAllRequest = await employeeRequestBL.GetAllRequestByEmployee(loggedInEmployee.Id);
            foreach (var request in employeeAllRequest)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }

        private async Task GetAllSolutionOfARequest()
        {

            int requestId = await GetValidIntegerInput("Enter the request id: ");
            var allSolutions = await employeeRequestBL.GetAllSolutionByRequestOfEmployee(requestId);
            foreach(var solution in allSolutions)
            {
                await Console.Out.WriteLineAsync(solution.ToString());
            }
        }
        private async Task ViewAllRequestByStatus()
        {
            string requestStatus = await GetValidStringInput("Enter the status of the request: ");
            var allRequestByStatus = await employeeRequestBL.GetAllRequestByStatus(loggedInEmployee.Id, requestStatus);
            foreach (var request in allRequestByStatus)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }

        private async Task AddRequestSolutionByAdmin()
        {
            await GetAllOpenRequestsByAdmin();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            string solutionDescription = await GetValidStringInput("Enter the solution description: ");
            var solution =await adminEmployeeBL.AddRequestSolutionByAdmin(requestId, solutionDescription, loggedInEmployee.Id);
            if(solution != null)
            {
                await Console.Out.WriteLineAsync("Solution added successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Solution failed");
            }
        }
        private async Task CloseRequestByAdmin()
        {
            await DisplayAllOpendAndAcceptedSolutionByEmployeeRequests();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            await adminEmployeeBL.MarkedRequestCloseByAdmin(requestId, loggedInEmployee.Id);

        }
        private async Task GetAllOpenRequestsByAdmin()
        {
            string requestStatus = "Open";
            var allRequests = await adminEmployeeBL.GetAllEmployeesRequestsByStatus(loggedInEmployee.Id, requestStatus);
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        private async Task GetAllClosedRequestsByAdmin()
        {
            string requestStatus = "Closed";
            var allRequests = await adminEmployeeBL.GetAllEmployeesRequestsByStatus(loggedInEmployee.Id, requestStatus);
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        private async Task GetAllRequestsByAdmin()
        {
            var allRequests = await adminEmployeeBL.GetAllRequest();
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }

        private async Task DisplayAllOpendAndAcceptedSolutionByEmployeeRequests()
        {
            if(loggedInEmployee.Role != "Admin")
            {
                await Console.Out.WriteLineAsync("You are not authorized to perform this operation");
                return;
            }
            var allRequests = await adminEmployeeBL.GetAllEmployeesRequestsByStatus(loggedInEmployee.Id, "Open");
            var allRequestWithAcceptedSolutions = allRequests.SelectMany(e => e.RequestSolutions).Where(e => e.IsSolved == true);
            
            foreach (var request in allRequestWithAcceptedSolutions)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }

        private async Task DisplayAllOpenedRequestOfEmployee()
        {
            var allRequests = await employeeRequestBL.GetAllRequestByStatus(loggedInEmployee.Id, "Open");
            foreach (var request in allRequests)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
        }
        async Task ResponseToSolution()
        {
            int solutionId = await GetValidIntegerInput("Enter the solution id: ");
            string response = await GetValidStringInput("Enter your response: ");
            var solution = await employeeRequestBL.ResponseToSolution(solutionId, response);
            if (solution != null)
            {
                await Console.Out.WriteLineAsync("Response added successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Response failed");
            }
        }

        async Task AcceptSolution()
        {
            int solutionId = await GetValidIntegerInput("Enter the solution id: ");
            var solution = await employeeRequestBL.AcceptSolution(solutionId);
            if (solution != null)
            {
                await Console.Out.WriteLineAsync("Solution accepted successfully");
                await Console.Out.WriteLineAsync(solution.ToString());
            }
            else
            {
                await Console.Out.WriteLineAsync("Solution failed");
            }
        }
        private async Task ViewRequestSolution()
        {
            await DisplayAllOpenedRequestOfEmployee();
            int requestId = await GetValidIntegerInput("Enter the request id: ");
            var allSolutions = await employeeRequestBL.GetAllSolutionByRequestOfEmployee(requestId);
            var allNotAcceptedSolutions = allSolutions.Where(e => e.IsSolved == false);
            foreach (var request in allNotAcceptedSolutions)
            {
                await Console.Out.WriteLineAsync(request.ToString());
            }
            await EmployeeSolutionMenu();
            int choice = await GetUserChoice(0, 3);
            bool exit = false;
            while (!exit)
            {
                switch (choice)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        await ResponseToSolution();
                        exit = true;
                        break;
                    case 2:
                        await AcceptSolution();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        

        public async Task<int> GetUserChoice(int minChoice, int maxChoice)
        {
            int choice;
            while (true)
            {
                await Console.Out.WriteAsync("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < minChoice || choice > maxChoice)
                {
                    await Console.Out.WriteLineAsync($"Invalid input! Please enter a number between {minChoice} and {maxChoice}.");
                }
                else
                {
                    break;
                }
            }
            return choice;
        }


        public async Task<int> GetValidIntegerInput(string prompt)
        {
            int result;
            bool isValidInput = false;
            do
            {
                await Console.Out.WriteAsync(prompt);
                string userInput = Console.ReadLine();

                isValidInput = int.TryParse(userInput, out result);

                if (!isValidInput)
                {
                    await Console.Out.WriteLineAsync("Invalid input. Please enter a valid integer.");
                }
            } while (!isValidInput);

            return result;
        }

        public async Task<string> GetValidStringInput(string prompt)
        {
            string userInput;

            do
            {
               await Console.Out.WriteAsync(prompt);
                userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    await Console.Out.WriteLineAsync("Invalid input. Please enter a non-empty string.");
                }
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.MainMenu(); 
        }
    }
}
