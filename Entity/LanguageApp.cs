using Dapper;
using System;

namespace Entity
{
    [Table("LanguageApp")]
    public class LanguageApp
    {
        [Key]
        [Column("LanguageId")]
        public int LanguageId { get; set; }

        [Column("LanguageName")]
        public string LanguageName { get; set; }

        [Column("LanguageShortName")]
        public string LanguageShortName { get; set; }

        [Column("LanguageCode")]
        public string LanguageCode { get; set; }

        [Column("LanguageIcon")]
        public string LanguageIcon { get; set; }

        [Column("LanguageMobileCode")]
        public string LanguageMobileCode { get; set; }

        [Column("LanguageActive")]
        public bool LanguageActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }
    }
}