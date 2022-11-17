namespace CupApplication.Data.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float VolumeInStock { get; set; }
        public float Price { get; set; }
        public float PortionVolume { get; set; }
        public float PortionPrice { get; set; }
    }
}
