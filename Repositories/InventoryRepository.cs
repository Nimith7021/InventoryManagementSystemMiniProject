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



        public List<Inventory> GetAllDetails()
        {
            return _context.inventories.Include(Inventory => Inventory.products).
                Include(Inventory => Inventory.suppliers).Include(Inventory => Inventory.transactionStocks)
                .ToList();
        }
    }
}
