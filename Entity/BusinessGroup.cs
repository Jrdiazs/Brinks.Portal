using System;

namespace Entity
{
    public class BusinessGroup
    {
        public Guid BusinessGroupId { get; set; }
        public Guid ThirdIdParent { get; set; }
        public Guid ThirdIdChildren { get; set; }
        public bool BusinessGroupActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}