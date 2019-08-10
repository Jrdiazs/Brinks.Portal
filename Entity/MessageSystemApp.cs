using System;

namespace Entity
{
    public class MessageSystemApp
    {
        public Guid MessageSystemId { get; set; }
        public long MessageCode { get; set; }
        public string MessageDescription { get; set; }
        public int LanguageId { get; set; }
        public bool MessageActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}