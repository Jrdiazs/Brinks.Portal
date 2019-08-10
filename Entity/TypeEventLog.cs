using System;

namespace Entity
{
    public class TypeEventLog
    {
        public int TypeEventLogId { get; set; }
        public string TypeEventName { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid? UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}