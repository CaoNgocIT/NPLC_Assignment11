using NgocCM2_NPLC_Assignment11.Models;

namespace NgocCM2_NPLC_Assignment11
{
    /// <summary>
    /// Manage menu and functions
    /// </summary>
    public class Management
    {
        private readonly Implementation implementation;
        private readonly DataContext context = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public Management()
        {
            implementation = new Implementation();
        }

        /// <summary>
        /// Display Main menu, check user's option and implement functions based on user's option
        /// </summary>
        public void Manage()
        {
            //Loop until user exits program
            while (true)
            {
                int option;
                bool isValid = false;
                Console.WriteLine("\n----------- PROGRAMMING LANGUAGUE OF DEPARTMENT -----------\n");
                Console.WriteLine("1. Return departments which have >= numberOfEmployee employees.");
                Console.WriteLine("2. Return employees has been working.");
                Console.WriteLine("3. Return list all employees know languageName.");
                Console.WriteLine("4. Return programing languages which employee has employeeId knows.");
                Console.WriteLine("5. Returns employees who know multiple programming languages.");
                Console.WriteLine("6. Returns List of Employees with pageIndex, pageSize, employeeName, order: ”ASC” or “DESC” ");
                Console.WriteLine("7. Return all departments including employees that belong to each department.");
                Console.WriteLine("0. Exit.\n");

                //Loop until user enters a valid option [0-7]
                do
                {
                    Console.Write("Enter an option: ");
                    isValid = int.TryParse(Console.ReadLine(), out option);
                    if (isValid == false || option < 0 || option > 78)
                    {
                        Console.WriteLine("--> The option must be positive integer and in [0,7]. Please try again!");
                    }
                } while (isValid == false || option < 0 || option > 7);

                //Implement funtion based on user's options
                switch (option)
                {
                    case 1:
                        GetDepartments();
                        break;
                    case 2:
                        GetEmployeesWorking();
                        break;
                    case 3:
                        GetEmployees();
                        break;
                    case 4:
                        GetLanguages();
                        break;
                    case 5:
                        GetSeniorEmployees();
                        break;
                    case 6:
                        GetEmployeesPaging();
                        break;
                    case 7:
                        GetDepartmentss();
                        break;
                    default:
                        Console.WriteLine("----------------- EXIT PROGRAM ---------------");
                        break;
                }
                if (option == 0)
                    break;
            }
        }

        /// <summary>
        /// Get department which has specific a number of employees or more
        /// </summary>
        private void GetDepartments()
        {
            int numberOfEmployee;
            bool isValid = false;

            //Loop until user enters a natural number
            do
            {
                Console.Write("Enter the number of employee: ");
                isValid = int.TryParse(Console.ReadLine(), out numberOfEmployee);

                //Check input is invalid or less than 0
                if (isValid == false || numberOfEmployee < 0)
                {
                    Console.WriteLine("The number of employee must be a natural number!");
                }
            } while (isValid == false || numberOfEmployee < 0);

            Console.WriteLine($"Department that has {numberOfEmployee} or more employee(s):");

            //Get department which has >= inputted-number employees
            var departments = implementation.GetDepartments(numberOfEmployee);

            //Result has no data
            if (departments.Count == 0) Console.WriteLine($"No department has {numberOfEmployee} or more employees!");

            //Display result departments
            else departments.ToList().ForEach(d => Console.WriteLine("\t" + d));
        }

        /// <summary>
        /// Get working employees
        /// </summary>
        /// <returns></returns>
        private void GetEmployeesWorking()
        {
            //Get employees who is still working
            var workingEmployees = implementation.GetEmployeesWorking();

            Console.WriteLine("Working employees:");

            //Result has no data
            if (workingEmployees.Count == 0) Console.WriteLine("All employees is out of work!");

            //Display result working employees
            else workingEmployees.ToList().ForEach(e => Console.WriteLine("\t" + e));
        }

        /// <summary>
        /// Get employees who know a specific programming language
        /// </summary>
        private void GetEmployees()
        {
            string language;

            //Loop until user enters a not-null string
            do
            {
                Console.Write("Enter a programming language: ");
                language = Console.ReadLine();

                //Input nothing or white spaces
                if (string.IsNullOrWhiteSpace(language))
                {
                    Console.WriteLine("Must enter a programming language!");
                }

            } while (string.IsNullOrWhiteSpace(language));

            //Get employees who knows inputted language
            var result = implementation.GetEmployees(language);

            //Result has no data
            if (result.Count == 0) Console.WriteLine($"No employee knows {language.Trim()}.");

            //Display result employees
            else
            {
                Console.WriteLine($"Employees know {language}: ");
                result.ToList().ForEach(e => Console.WriteLine("\t" + e));
            }
        }

        /// <summary>
        /// Get all programming language that an employee with a specific ID knows
        /// </summary>      
        private void GetLanguages()
        {
            int employeeId;
            bool isValid = false, isExist = false;

            //Loop until user enters a valid and existing employee id 
            do
            {
                Console.Write("Enter an Employee Id: ");
                isValid = int.TryParse(Console.ReadLine(), out employeeId);

                //Id is invalid
                if (!isValid)
                {
                    Console.WriteLine("Id must be a natural number!");
                }

                //Id is valid
                else
                {
                    var employees = context.Employees.ToList();

                    //Check inputted id exists or not
                    isExist = employees.Any(e => e.EmployeeId == employeeId);

                    //Id exists
                    if (isExist)
                    {
                        //Get all programming language that employee with inputted id knows
                        var result = implementation.GetLanguages(employeeId);

                        //Result has no data
                        if (result.Count == 0) Console.WriteLine($"Employee with Id: {employeeId} doesn't no any programming languages.");

                        //Display programming language result
                        else
                        {
                            Console.WriteLine("Programming language known:");
                            result.ToList().ForEach(l => Console.WriteLine("\t" + l));
                        }
                    }
                    //Id doesn't exist
                    else
                    {
                        Console.WriteLine($"There is no employee with Id: {employeeId}.");
                    }
                }
            } while (!isValid || !isExist);

        }

        /// <summary>
        /// Get all employees who knows at least 2 programming languages
        /// </summary>
        /// <returns></returns>
        private void GetSeniorEmployees()
        {
            //Get all employees who knows at least 2 programming languages
            var result = implementation.GetSeniorEmployee();

            //Result has no data
            if (result.Count == 0) Console.WriteLine("There is no employee knowing multiple programming languages.");

            //Display employees result
            else
            {
                Console.WriteLine("Employees know multiple programming languages:");
                result.ToList().ForEach(result => Console.WriteLine("\t" + result));
            }
        }

        /// <summary>
        /// Get employees by name and paging the result by page index and page size
        /// </summary>
        private void GetEmployeesPaging()
        {
            int pageIndex, pageSize;
            string nameToSearch, order;

            //Input and validate page index 
            pageIndex = ValidateNumber("Enter the page index: ");

            //Input and validate page size
            pageSize = ValidateNumber("Enter the page size: ");

            Console.Write("Enter a name to search: ");
            nameToSearch = Console.ReadLine();

            //Input an validate order 
            order = ValidateOrder("Enter an order (ASC/DESC): ");

            //Get and sort employees by inputted-name and page the result by inputted page index and inputted page size
            var result = implementation.GetEmployeePaging(pageIndex, pageSize, nameToSearch, order);

            //Result has no data
            if (result.Count == 0)
            {
                Console.WriteLine("No result!");
            }

            //Display result
            else
            {
                Console.WriteLine($"\nResult:");
                result.ToList().ForEach(e => Console.WriteLine(e));
                Console.WriteLine($"\n\t\t\t------------ Page: {pageIndex} ------------");
            }
        }

        /// <summary>
        /// Get all departments and all employees that belongs to each department
        /// </summary>
        private void GetDepartmentss()
        {
            implementation.GetDepartmentss();
        }

        /// <summary>
        /// Validate a number
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static int ValidateNumber(string message)
        {
            int number;
            bool isValid;

            //Loop until user enters a valid and greater than 0 number
            do
            {
                Console.Write(message);

                isValid = int.TryParse(Console.ReadLine(), out number);

                //Check inputted number is invalid or less than 1
                if (!isValid || number < 1)
                {
                    Console.WriteLine("Must be a natural number and greater than 0!");
                }

            } while (!isValid || number < 1);

            return number;
        }

        /// <summary>
        /// Validate a string order
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string ValidateOrder(string message)
        {
            string order;
            bool isValid;

            //Loop until user enters "asc" or "desc" order
            do
            {
                Console.Write(message);
                order = Console.ReadLine();

                //Default order is ASC, when order is null
                if (string.IsNullOrWhiteSpace(order))
                {
                    order = "ASC";
                    break;
                }

                //Check order is asc or desc
                isValid = (order.ToUpper().Trim().Equals("ASC") || (order.ToUpper().Trim().Equals("DESC")));

                //Invalid order
                if (!isValid)
                {
                    Console.WriteLine("Order must be either ASC or DESC!");
                }

                //Valid order
                else
                {
                    break;
                }
            } while (!isValid);

            return order;
        }
    }
}
