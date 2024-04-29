using BackendTeamwork.Entities;
using System;
using System.Collections.Generic;

namespace BackendTeamwork.Abstractions
{
    public interface WishlistItemService
    {
        IEnumerable<WishlistItem> FindMany();
        WishlistItem FindOne(Guid id);
        WishlistItem CreateOne(WishlistItem newItem);
        WishlistItem UpdateOne(Guid id, WishlistItem updatedItem);
        bool DeleteOne(Guid id);
    }
}
