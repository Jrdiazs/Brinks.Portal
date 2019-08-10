using System;

namespace Entity
{
    public class TypeRol
    {
        public int TypeRolId { get; set; }
        public string TypeRolName { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}