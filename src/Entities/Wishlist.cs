<<<<<<< HEAD
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
=======
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendTeamwork.Entities
{
    public class Wishlist
    {
        [Key]
        public Guid Id { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }
        public IEnumerable<Product> Products { get; set; }
>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe

    }
}
