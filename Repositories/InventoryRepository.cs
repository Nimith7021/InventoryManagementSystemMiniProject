using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories
{
    internal class InventoryRepository
    {
        private readonly InventoryContext _context;
       

        public InventoryRepository(InventoryContext context)
        {
            _context = context;
           
        }

       

        public List<Inventory> GetAllProducts()
        {
            return _context.inventories.Include(Inventory=>Inventory.products).ToList();
        }

        public List<Inventory> GetAllSuppliers()
        {
            return _context.inventories.Include(Inventory => Inventory.suppliers).ToList();
        }

        public List<Inventory> GetAllTransactions()
        {
            return _context.inventories.Include(Inventory=>Inventory.transactionStocks).ToList();
        }
    }
}
