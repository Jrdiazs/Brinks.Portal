using System;

namespace Entity
{
    public class UserRol
    {
        public Guid UserRolId { get; set; }
        public Guid UserId { get; set; }
        public Guid RolId { get; set; }
        public bool UserRolActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}