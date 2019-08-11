using Dapper;
using System;

namespace Entity
{
    [Table("TypeRol")]
    public class TypeRol
    {
        [Key]
        [Column("TypeRolId")]
        public int TypeRolId { get; set; }

        [Column("TypeRolName")]
        public string TypeRolName { get; set; }

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