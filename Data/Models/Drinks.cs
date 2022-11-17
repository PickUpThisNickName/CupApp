namespace CupApplication.Data.Models
{
    public class Drinks
    {
        // public int Id { get; set; }
        // public string? name { get; set; }
        // public string? shortDesc { get; set; }
        // public string? longDesc { get; set; }
        // public string? img { get; set; }
        // public ushort price { get; set; }
        // public bool isFavorite { get; set; }
        // public bool aviable { get; set; }
        // public int categoryID { get; set; }
        // public virtual Category? Category { set; get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Cup { get; set; }
        public string Source1 { get; set; }
        public string Source2 { get; set; }
        public string Source3 { get; set; }
    }
}
