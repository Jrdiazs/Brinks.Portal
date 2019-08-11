using Dapper;
using System;

namespace Entity
{
    [Table("ControlsLanguage")]
    public class ControlsLanguage
    {
        [Key]
        [Column("ControlId")]
        public Guid ControlId { get; set; }

        [Column("ControlName")]
        public string ControlName { get; set; }

        [Column("FormId")]
        public int FormId { get; set; }

        [Column("LanguageId")]
        public int LanguageId { get; set; }

        [Column("ControlDescription")]
        public string ControlDescription { get; set; }

        [Column("ForeignKeyTable")]
        public string ForeignKeyTable { get; set; }

        [Column("TableName")]
        public string TableName { get; set; }

        [Column("ControlActive")]
        public bool ControlActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public LanguageApp Language { get; set; }

        [NotMapped]
        public FormsApp Forms { get; set; }
    }
}