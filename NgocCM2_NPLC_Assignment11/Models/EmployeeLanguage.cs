namespace NgocCM2_NPLC_Assignment11.Models
{
    public class EmployeeLanguage
    {
        public int EmployeeId { get; set; }
        public int LanguageId { get; set; }

        public EmployeeLanguage()
        {
        }

        public EmployeeLanguage(int employeeId, int languageId)
        {
            EmployeeId = employeeId;
            LanguageId = languageId;
        }
    }
}
