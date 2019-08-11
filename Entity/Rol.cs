using Dapper;
using System;

namespace Entity
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("RolName")]
        public string RolName { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("TypeRolId")]
        public int? TypeRolId { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }
    }
}