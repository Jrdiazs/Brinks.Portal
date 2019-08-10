using System;

namespace Entity
{
    public class FormsApp
    {
        public int FormId { get; set; }
        public string FormControllerName { get; set; }
        public bool FormActive { get; set; }
        public string FormDescriptions { get; set; }
        public bool FormBlocked { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}