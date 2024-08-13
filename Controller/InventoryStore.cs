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
    internal class InventoryStore
    {
        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Inventory Manager\n" +
                        "Which Operation do you wish to perform\n" +
                        "1.Generate Report\n" +
                        "2.Back to Main Menu\n" 
                      );

                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);

                
                
            }
        }

        public static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    GenerateReport();
                    break;
                case 2:
                    InventoryStore.InventoryMenu();
                    break;
                default:
                    Console.WriteLine("Enter a valid choice");
                    break;
            }
        }

        public static void GenerateReport()
        {
            var inventory = InventoryManagement.DisplayProducts();
            Console.WriteLine("-----------------PRODUCTS-----------------------");
            foreach (Inventory IndividualInventory in inventory)
            {
                Console.WriteLine(IndividualInventory);
                var products = IndividualInventory.products;
                products.ForEach(product => Console.WriteLine(product));
            }

            Console.WriteLine("-----------------SUPPLIERS----------------------");
            inventory = InventoryManagement.DisplaySuppliers();
            foreach (Inventory IndividualInventory in inventory)
            {
                Console.WriteLine(IndividualInventory);
                var products = IndividualInventory.suppliers;
                products.ForEach(supplier => Console.WriteLine(supplier));
            }

            Console.WriteLine("-----------------TRANSACTIONS----------------------");
            inventory = InventoryManagement.DisplayTransactions();
            foreach (Inventory IndividualInventory in inventory)
            {
                Console.WriteLine(IndividualInventory);
                var products = IndividualInventory.transactionStocks;
                products.ForEach(transaction => Console.WriteLine(transaction));
            }
        }

        public static void InventoryMenu()
        {
            while (true)
            {
                Console.WriteLine($"WELCOME TO INVENTORY MANAGEMENT SYSTEM\n" +
                    $"You have the following menus to choose from : \n" +
                    $"1.Product Menu\n" +
                    $"2.Supplier Menu\n" +
                    $"3.Transaction Menu\n" +
                    $"4.Inventory Manager\n" +
                    $"5.Exit Application\n");
                Console.WriteLine("Which menu do you want?\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ProductStore.DisplayMenu();
                        break;
                    case 2:
                        SupplyStore.DisplayMenu();
                        break;
                    case 3:
                        TransactionStore.DisplayMenu();
                        break;
                    case 4:
                        DisplayMenu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;

                }
            }
        }
    }
}
