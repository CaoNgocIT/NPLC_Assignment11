using NgocCM2_NPLC_Assignment11.Models;

namespace NgocCM2_NPLC_Assignment11
{
    /// <summary>
    /// Implementation of retrieving datas
    /// </summary>
    public class Implementation
    {
        private readonly DataContext context;

        /// <summary>
        /// Constructor
        /// </summary>
        public Implementation()
        {
            context = new DataContext();
        }

        /// <summary>
        /// Get department which has specific a number of employees or more
        /// </summary>
        /// <param name="numberOfEmployee"></param>
        /// <returns></returns>
        public ICollection<Department> GetDepartments(int numberOfEmployee)
        {
            var departments = from d in context.Departments
                              join e in context.Employees
                              on d.DepartmentId equals e.DepartmentId
                              group e by d into x
                              where x.Count() >= numberOfEmployee
                              select new Department
                              {
                                  DepartmentId = x.Key.DepartmentId,
                                  DepartmentName = x.Key.DepartmentName,
                              };

            return departments.ToList();
        }

        /// <summary>
        /// Get working employees (status = 1)
        /// </summary>
        /// <returns></returns>
        public ICollection<Employee> GetEmployeesWorking()
        {
            var employees = from e in context.Employees
                            where e.Status == 1
                            select new Employee
                            {
                                EmployeeId = e.EmployeeId,
                                EmployeeName = e.EmployeeName,
                                Address = e.Address,
                                DepartmentId = e.DepartmentId,
                                HiredDate = e.HiredDate,
                                Age = e.Age,
                                Status = e.Status,
                            };
            return employees.ToList();
        }

        /// <summary>
        /// Get employees who know a specific programming language
        /// </summary>
        /// <param name="languageName"></param>
        /// <returns></returns>
        public ICollection<Employee> GetEmployees(string languageName)
        {
            var employees = from e in context.Employees
                            join el in context.EmployeeLanguages
                            on e.EmployeeId equals el.EmployeeId
                            join pl in context.ProgrammingLanguages
                            on el.LanguageId equals pl.LanguageId
                            where pl.LanguageName.ToLower() == languageName.ToLower().Trim()
                            select new Employee
                            {
                                EmployeeId = e.EmployeeId,
                                EmployeeName = e.EmployeeName,
                                Status = e.Status,
                                Address = e.Address,
                                Age = e.Age,
                                DepartmentId = e.DepartmentId,
                                HiredDate = e.HiredDate
                            };
            return employees.ToList();
        }

        /// <summary>
        /// Get all programming language that an employee with a specific ID knows
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public ICollection<ProgrammingLanguage> GetLanguages(int employeeId)
        {
            var result = from pl in context.ProgrammingLanguages
                         join el in context.EmployeeLanguages
                         on pl.LanguageId equals el.LanguageId
                         where el.EmployeeId == employeeId
                         select new ProgrammingLanguage
                         {
                             LanguageId = pl.LanguageId,
                             LanguageName = pl.LanguageName,
                         };
            return result.ToList();
        }

        /// <summary>
        /// Get all employees who knows at least 2 programming languages
        /// </summary>
        /// <returns></returns> 
        public ICollection<Employee> GetSeniorEmployee()
        {
            var employees = from e in context.Employees
                            join el in context.EmployeeLanguages
                            on e.EmployeeId equals el.EmployeeId
                            group el by e into x
                            where x.Count() >= 2
                            select new Employee
                            {
                                EmployeeId = x.Key.EmployeeId,
                                EmployeeName = x.Key.EmployeeName,
                                Status = x.Key.Status,
                                Address = x.Key.Address,
                                Age = x.Key.Age,
                                DepartmentId = x.Key.DepartmentId,
                                HiredDate = x.Key.HiredDate
                            };

            return employees.ToList();
        }

        /// <summary>
        /// Get employees by name and paging the result by page index and page size
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="employeeName"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public ICollection<Employee> GetEmployeePaging(int pageIndex = 1, int pageSize = 10, string employeeName = null, string order = "ASC")
        {
            var result = context.Employees;

            //Get a list of employees whose name contains a specific string name
            result = result.Where(e => e.EmployeeName.Contains(employeeName)).ToList();

            //Order the list ascending
            if (order.ToUpper() == "ASC")
            {
                result = result.OrderBy(e => e.EmployeeName).ToList();
            }

            //Order the list descending
            else if (order.ToUpper() == "DESC")
            {
                result = result.OrderByDescending(e => e.EmployeeName).ToList();
            }

            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// Get all departments and all employees that belongs to each department
        /// </summary>
        public void GetDepartmentss()
        {
            List<Department> departments = context.Departments.ToList();
            departments.ForEach(x =>
            {
                var employees = (from e in context.Employees
                                 join d in context.Departments
                                 on e.DepartmentId equals d.DepartmentId
                                 where e.DepartmentId == x.DepartmentId
                                 select e).ToList();

                Console.WriteLine($"{x.DepartmentName} department has {employees.Count} employees:\n");
                employees.ForEach(e => Console.WriteLine("\t" + e));
                Console.WriteLine();
            }
            );
        }
    }
}
