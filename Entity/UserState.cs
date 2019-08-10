using System;

namespace Entity
{
    public class UserState
    {
        public int UserStateId { get; set; }
        public string UserStateName { get; set; }
        public string UserStateShortName { get; set; }
        public bool UserStateActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}