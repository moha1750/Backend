
namespace BackendTeamwork.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public Guid Category_id { get; set; }

        public Product(Guid id, string name, int price, string image, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            Description = description;
            Category_id = new Guid();
        }

    }
}