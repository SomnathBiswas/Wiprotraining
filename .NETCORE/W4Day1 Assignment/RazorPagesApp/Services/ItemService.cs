using System.Collections.Generic;
using RazorPagesApp.Models;

namespace RazorPagesApp.Services
{
    public class ItemService : IItemService
    {
        private readonly List<Item> _items = new();
        private int _next = 1;
        public IEnumerable<Item> GetAll() => _items;
        public void Add(Item item) {
            item.Id = _next++;
            _items.Add(item);
        }
    }
}