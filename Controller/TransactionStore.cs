using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repo;

namespace InventoryManagementSystem.Controller
{
    internal class TransactionStore
    {
        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Transaction Application\n" +
                        "Which Operation do you wish to perform\n" +
                        "1.Add Stock\n" +
                        "2.Remove Stock\n" +
                        "3.View Transaction History\n" +
                        "4.Go Back To main menu\n"
                        );

                try
                {
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (ProductNotExistException pne) {
                    Console.WriteLine(pne.Message);
                }
                catch(NegativeStockException nse)
                {
                    Console.WriteLine(nse.Message);
                }
            }
        }

        public static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddStock();
                    break;
                case 2:
                    RemoveStock();
                    break;
                case 3:
                    DisplayTransactions();
                    break;
                case 4:
                    InventoryStore.InventoryMenu();
                    break;
                default:
                    Console.WriteLine("Enter a valid input");
                    break;
            }
        }

        public static void AddStock()
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity you want to add");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the inventory Id");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            TransactionManagement.AddQuantity(id,quantity,inventoryId);
            Console.WriteLine("Stock Added successfully");
        }

        public static void RemoveStock()
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity you want to remove");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the inventory Id");
            int inventoryId = Convert.ToInt32(Console.ReadLine());
            TransactionManagement.RemoveQuantity(id, quantity,inventoryId);
            Console.WriteLine("Stock successfully removed");
        }

        public static void DisplayTransactions()
        {
            var transactionList = TransactionManagement.DisplayTransactionList();
            transactionList.ForEach(transaction => Console.WriteLine(transaction));
        }
    } 
}