using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Models;
using System.Collections.ObjectModel;
using Catalog.Services;
using System.Threading.Tasks;

namespace Catalog.Data 
{
    public class ItemData : IDataStore<Item>
    {
        readonly List<Item> Items;

        public ItemData()
        {
            Items = new List<Item>();
            for (int i = 0; i < 10; i++)
            {
                Items.Add
                   (
                   new Item()
                   {
                       Id = $"{i}",
                       Text = $"Наименование товара {i}",
                       Description = "Описание",
                       Img = "plug.png"
                   }

                   );

            }
        }



        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}
