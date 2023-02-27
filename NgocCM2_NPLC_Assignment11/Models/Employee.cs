namespace NgocCM2_NPLC_Assignment11.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public DateTime HiredDate { get; set; }
        public int Status { get; set; } // 0: Out-of-work, 1:Working

        public Employee()
        {

        }

        public Employee(int employeeId, int departmentId, string employeeName, int age, string address, DateTime hiredDate, int status)
        {
            EmployeeId = employeeId;
            DepartmentId = departmentId;
            EmployeeName = employeeName;
            Age = age;
            Address = address;
            HiredDate = hiredDate;
            Status = status;
        }

        public override string? ToString()
        {
            return string.Format("{0,-10}{1,-25}{2,-10}{3,-15}{4,-15}{5,-1}", EmployeeId, EmployeeName, Age, Address, HiredDate.ToShortDateString(), Status);
        }
    }
}
