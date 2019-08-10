using System;

namespace Entity
{
    public class Rol
    {
        public Guid RolId { get; set; }
        public string RolName { get; set; }
        public DateTime CreationDate { get; set; }
        public int? TypeRolId { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}