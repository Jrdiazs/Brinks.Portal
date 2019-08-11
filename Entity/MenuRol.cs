using Dapper;
using System;

namespace Entity
{
    [Table("MenuRol")]
    public class MenuRol
    {
        [Key]
        [Column("MenuRolId")]
        public Guid MenuRolId { get; set; }

        [Column("MenuId")]
        public int MenuId { get; set; }

        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("MenuRolActive")]
        public bool MenuRolActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public Menu Menu { get; set; }

        [NotMapped]
        public Rol Rol { get; set; }
    }
}