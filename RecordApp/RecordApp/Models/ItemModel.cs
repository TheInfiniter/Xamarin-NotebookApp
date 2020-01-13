using SQLite;

namespace RecordApp.Models
{
    public class ItemModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
    }
}
