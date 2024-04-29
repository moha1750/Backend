using BackendTeamwork.Entities;
using System;
using System.Collections.Generic;

namespace BackendTeamwork.Abstractions
{
    public interface IWishlistItemService
    {
        IEnumerable<WishlistItem> FindAllItems();
        WishlistItem FindItemById(Guid id);
        WishlistItem AddNewItem(WishlistItem newItem);
        WishlistItem UpdateItem(Guid id, WishlistItem updatedItem);
        bool DeleteItem(Guid id);
    }
}
