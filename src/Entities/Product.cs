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

    }
}