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


        
        public static List<Inventory> DisplayProducts()
        {
            var inventory = repository.GetAllProducts();
            return inventory;
        }

        public static List<Inventory> DisplaySuppliers()
        {
            var inventory = repository.GetAllSuppliers();
            return inventory;
        }

        public static List<Inventory> DisplayTransactions()
        {
            var inventory = repository.GetAllTransactions();
            return inventory;
        }




    }
}
