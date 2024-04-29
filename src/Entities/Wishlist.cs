using System;

namespace BackendTeamwork.Entities
{
    public class WishlistItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string productId { get; set; }

        public string wishlistId { get; set; }



        public WishlistItem(Guid id, string name, int price, string image, string description, string productId, string wishlistId)
        {
            Id = id;
            Name = name;
            Price = price;
            Image = image;
            Description = description;
            productId = productId;
            wishlistId = wishlistId;
            
            
        

        
        }

    }
}
