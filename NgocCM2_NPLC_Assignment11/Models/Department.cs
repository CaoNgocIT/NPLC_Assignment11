namespace NgocCM2_NPLC_Assignment11.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Department()
        {

        }
        public Department(int departmentId, string departmentName)
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
        }

        public override string? ToString()
        {
            return $"{DepartmentId}\t{DepartmentName}";
        }
    }
}
