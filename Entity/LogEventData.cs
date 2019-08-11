using Dapper;
using System;

namespace Entity
{
    [Table("LogEventData")]
    public class LogEventData
    {
        [Key]
        [Column("LogEventDataId")]
        public Guid LogEventDataId { get; set; }

        [Column("LogEventTypeId")]
        public int LogEventTypeId { get; set; }

        [Column("TableNameApp")]
        public string TableNameApp { get; set; }

        [Column("DateCreation")]
        public DateTime DateCreation { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("NewDataXML")]
        public string NewDataXML { get; set; }

        [Column("OldDataXML")]
        public string OldDataXML { get; set; }

        [Column("IP")]
        public string IP { get; set; }

        [Column("NewDataJSON")]
        public string NewDataJSON { get; set; }

        [Column("OldDataJSON")]
        public string OldDataJSON { get; set; }

        [NotMapped]
        public TypeEventLog TypeEventLog { get; set; }
    }
}