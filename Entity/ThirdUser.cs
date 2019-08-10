using System;

namespace Entity
{
    public class ThirdUser
    {
        public Guid ThirdUserId { get; set; }
        public Guid UserId { get; set; }
        public Guid ThirdId { get; set; }
        public bool ThirdUserActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}