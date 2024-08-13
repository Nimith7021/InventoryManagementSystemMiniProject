using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    internal class TransactionRepository
    {
        private readonly InventoryContext _context;
        public TransactionRepository(InventoryContext context)
        {
            _context = context;
        }

       public List<TransactionStock> Display()
        {
            return _context.transactions.ToList();
        }

       
    }
}
