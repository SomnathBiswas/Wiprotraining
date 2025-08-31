using System.Collections.Generic;
using RazorPagesApp.Models;

namespace RazorPagesApp.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();
        void Add(Item item);
    }
}