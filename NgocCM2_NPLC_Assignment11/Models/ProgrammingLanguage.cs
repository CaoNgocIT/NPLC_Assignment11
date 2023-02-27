namespace NgocCM2_NPLC_Assignment11.Models
{
    public class ProgrammingLanguage
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }

        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int languageId, string languageName)
        {
            LanguageId = languageId;
            LanguageName = languageName;
        }

        public override string? ToString()
        {
            return $"{LanguageId}\t{LanguageName}";
        }
    }

}
