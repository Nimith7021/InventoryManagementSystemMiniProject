using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Repo
{
    internal class InventoryManagement
    {
        static InventoryRepository repository = new InventoryRepository(new InventoryContext());



        public static List<Inventory> DisplayEveryDetail()
        {
            var inventory = repository.GetAllDetails();
            return inventory;
        }




    }
}
