using System;

namespace Entity
{
    public class MenuRol
    {
        public Guid MenuRolId { get; set; }
        public int MenuId { get; set; }
        public Guid RolId { get; set; }
        public bool MenuRolActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}