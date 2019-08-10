using System;

namespace Entity
{
    public class ThirdRol
    {
        public Guid ThirdRolId { get; set; }
        public Guid RolId { get; set; }
        public Guid ThirdId { get; set; }
        public bool ThirdRolActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}