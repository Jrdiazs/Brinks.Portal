using System;

namespace Entity
{
    public class UserPwHistory
    {
        public Guid UserPwHistoryId { get; set; }
        public Guid UserId { get; set; }
        public string UserPw { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
    }
}