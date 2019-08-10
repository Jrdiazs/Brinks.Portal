using System;

namespace Entity
{
    public class LanguageApp
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageShortName { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageIcon { get; set; }
        public string LanguageMobileCode { get; set; }
        public bool LanguageActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}