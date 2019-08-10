using System;

namespace Entity
{
    public class TableApp
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string TableIdName { get; set; }
        public string ConvertName { get; set; }
        public string ViewName { get; set; }
        public string DescriptionName { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}