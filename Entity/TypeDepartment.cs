using Dapper;
using System;

namespace Entity
{
    [Table("TypeDepartment")]
    public class TypeDepartment
    {
        [Key]
        [Column("TypeDepartmentId")]
        public int TypeDepartmentId { get; set; }

        [Column("TypeDepartmentName")]
        public string TypeDepartmentName { get; set; }

        [Column("TypeDepartmentActive")]
        public bool TypeDepartmentActive { get; set; }

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