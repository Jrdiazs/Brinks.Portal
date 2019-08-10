using System;

namespace Entity
{
    public class CurrentSession
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DateClosesSesion { get; set; }
    }
}