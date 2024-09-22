namespace backend.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Checked { get; set; } = false;
    }
}