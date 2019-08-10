using System;

namespace Entity
{
    public class LogEventData
    {
        public Guid LogEventDataId { get; set; }
        public int LogEventTypeId { get; set; }
        public string TableNameApp { get; set; }
        public DateTime DateCreation { get; set; }
        public Guid UserCreationId { get; set; }
        public string NewDataXML { get; set; }
        public string OldDataXML { get; set; }
        public string IP { get; set; }
        public string NewDataJSON { get; set; }
        public string OldDataJSON { get; set; }
    }
}