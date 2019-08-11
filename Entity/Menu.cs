using Dapper;
using System;

namespace Entity
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [Column("MenuId")]
        public int MenuId { get; set; }

        [Column("MenuName")]
        public string MenuName { get; set; }

        [Column("MenuUrl")]
        public string MenuUrl { get; set; }

        [Column("MenuIcon")]
        public string MenuIcon { get; set; }

        [Column("MenuParentId")]
        public int? MenuParentId { get; set; }

        [Column("IsMenuParent")]
        public int IsMenuParent { get; set; }

        [Column("MenuActive")]
        public bool MenuActive { get; set; }

        [Column("MenuOrder")]
        public int MenuOrder { get; set; }

        [Column("MenuLocalizationId")]
        public int MenuLocalizationId { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public Menu MenuParent { get; set; }

        [NotMapped]
        public MenuLocalization MenuLocalization { get; set; }
    }
}