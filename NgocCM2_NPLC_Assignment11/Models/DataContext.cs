namespace NgocCM2_NPLC_Assignment11.Models
{
    public class DataContext
    {
        public ICollection<Department> Departments { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }

        public DataContext()
        {
            //List of departments
            Departments = new List<Department>()
            {
                new Department(departmentId: 1, departmentName: "Administration"),
                new Department(departmentId: 2, departmentName: "Human resources"),
                new Department(departmentId: 3, departmentName: "Marketing"),
                new Department(departmentId: 4, departmentName: "Finance"),
                new Department(departmentId: 5, departmentName: "IT"),
            };

            //List of employees
            Employees = new List<Employee>()
            {
                new Employee(employeeId: 1, departmentId: 1, employeeName: "Christine Collins", age: 46, address: "UK", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 2, departmentId: 1, employeeName: "Triston Brown", age: 45, address: "UK", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 3, departmentId: 2, employeeName: "Karsyn Cooper", age: 26, address: "UK", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 4, departmentId: 2, employeeName: "Vincent McConnell", age: 30, address: "Ireland", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 5, departmentId: 3, employeeName: "Ruth Summers", age: 28, address: "France", hiredDate:DateTime.Now, status: 0),

                new Employee(employeeId: 6, departmentId: 3, employeeName: "Monique Cherry", age: 27, address: "Italy", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 7, departmentId: 3, employeeName: "Cloe Galloway", age: 27, address: "Belgium", hiredDate:DateTime.Now, status: 0),

                new Employee(employeeId: 8, departmentId: 4, employeeName: "Meredith English", age: 31, address: "UK", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 9, departmentId: 4, employeeName: "Eliza Beltran", age: 29, address: "UK", hiredDate:DateTime.Now, status: 0),

                new Employee(employeeId: 10, departmentId: 5, employeeName: "Marin Harvey", age: 22, address: "Canada", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 11, departmentId: 5, employeeName: "Leroy Barron", age: 24, address: "US", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 12, departmentId: 5, employeeName: "Johnathon Knight", age: 22, address: "Wales", hiredDate:DateTime.Now, status: 0),   

                new Employee(employeeId: 13, departmentId: 5, employeeName: "Valentina Barrera", age: 19, address: "Russia", hiredDate:DateTime.Now, status: 0),

                new Employee(employeeId: 14, departmentId: 5, employeeName: "Tien Nguyen", age: 20, address: "Vietnam", hiredDate:DateTime.Now, status: 1),

                new Employee(employeeId: 15, departmentId: 5, employeeName: "Joaquin Chan", age: 23, address: "Taiwan", hiredDate:DateTime.Now, status: 1),
            };

            //List of programming languages
            ProgrammingLanguages = new List<ProgrammingLanguage>()
            {
                new ProgrammingLanguage(languageId: 1, languageName: "Java"),
                new ProgrammingLanguage(languageId: 2, languageName: "C++"),
                new ProgrammingLanguage(languageId: 3, languageName: "Ruby"),
                new ProgrammingLanguage(languageId: 4, languageName: "Python"),
                new ProgrammingLanguage(languageId: 5, languageName: "C#"),
                new ProgrammingLanguage(languageId: 6, languageName: "JavaScript"),
                new ProgrammingLanguage(languageId: 7, languageName: "Swift"),
                new ProgrammingLanguage(languageId: 8, languageName: "PHP"),
            };

            //List of ID of languages and Id of employee knowing that language
            EmployeeLanguages = new List<EmployeeLanguage>()
            {
                new EmployeeLanguage(employeeId: 10, languageId: 1),
                new EmployeeLanguage(employeeId: 10, languageId: 6),
                new EmployeeLanguage(employeeId: 10, languageId: 8),
                new EmployeeLanguage(employeeId: 11, languageId: 2),
                new EmployeeLanguage(employeeId: 12, languageId: 3),
                new EmployeeLanguage(employeeId: 12, languageId: 7),
                new EmployeeLanguage(employeeId: 13, languageId: 1),
                new EmployeeLanguage(employeeId: 13, languageId: 5),
                new EmployeeLanguage(employeeId: 14, languageId: 2),
                new EmployeeLanguage(employeeId: 14, languageId: 5),
                new EmployeeLanguage(employeeId: 15, languageId: 4),
                new EmployeeLanguage(employeeId: 15, languageId: 8),
            };
        }
    }
}
