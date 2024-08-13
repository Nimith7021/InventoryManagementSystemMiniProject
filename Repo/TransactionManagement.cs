using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Repo
{
    internal class TransactionManagement
    {
        static TransactionRepository transactionRepo = new TransactionRepository(new InventoryContext());
        public static void AddQuantity(int id , int quantity,int inventoryId)
        {
            if (ProductManagement.repository.CheckProductId(id))
            {
                ProductManagement.repository.AddStockItems(id, quantity,inventoryId);
            }
            else
            {
                throw new ProductNotExistException("Product doesn't exist");
            }
        }

        public static void RemoveQuantity(int id, int quantity,int inventoryId)
        {
            if (ProductManagement.repository.CheckProductId(id))
            {
                
                ProductManagement.repository.RemoveStockItems(id, quantity,inventoryId);
            }
            else
            {
                throw new ProductNotExistException("Product doesn't exist");
            }
        }

        public static List<TransactionStock> DisplayTransactionList()
        {
            return transactionRepo.Display();
        }
    }
}
