<<<<<<< HEAD
using BackendTeamwork.Entities;
using System;
using System.Collections.Generic;
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendTeamwork.Entities;
>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistRepository
    {
<<<<<<< HEAD
<<<<<<< HEAD
        IEnumerable<WishlistItem> FindMany();
        WishlistItem FindOne(Guid id);
        WishlistItem CreateOne(WishlistItem newItem);
        WishlistItem UpdateOne(WishlistItem updatedItem);
        bool DeleteOne(Guid id);
    }
}
=======
        public IEnumerable<Wishlist> FindMany();
=======
        public IEnumerable<Wishlist> FindMany(int limit, int offset);
>>>>>>> 6f23f28f76076683bcd66ffaf1b41c64d3118912
        public Task<Wishlist?> FindOne(Guid wishlistId);

        public Task<Wishlist> AddOneProduct(Wishlist wishlist, Product product);
        public Task<Wishlist> CreateOne(Wishlist newWishlist);

        public Task<Wishlist> UpdateOne(Wishlist updatedWishlist);

        public Task<Wishlist> DeleteOne(Wishlist targetWishlist);
    }
}
>>>>>>> da7de1e4169592927dc0362fcd7f741974b62bbe
