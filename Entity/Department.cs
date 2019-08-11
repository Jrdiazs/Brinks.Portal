using Dapper;
using System;

namespace Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Column("DepartmentId")]
        public int DepartmentId { get; set; }

        [Column("CountryId")]
        public int CountryId { get; set; }

        [Column("DepartmentName")]
        public string DepartmentName { get; set; }

        [Column("DeparmentActive")]
        public bool DeparmentActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public Country Country { get; set; }
    }
}