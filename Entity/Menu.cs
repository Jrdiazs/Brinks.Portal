using System;

namespace Entity
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string MenuIcon { get; set; }
        public int? MenuParentId { get; set; }
        public int IsMenuParent { get; set; }
        public bool MenuActive { get; set; }
        public int MenuOrder { get; set; }
        public int MenuLocalizationId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}