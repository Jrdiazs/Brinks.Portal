using Dapper;
using System;

namespace Entity
{
    [Table("FormsApp")]
    public class FormsApp
    {
        [Key]
        [Column("FormId")]
        public int FormId { get; set; }

        [Column("FormControllerName")]
        public string FormControllerName { get; set; }

        [Column("FormActive")]
        public bool FormActive { get; set; }

        [Column("FormDescriptions")]
        public string FormDescriptions { get; set; }

        [Column("FormBlocked")]
        public bool FormBlocked { get; set; }

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