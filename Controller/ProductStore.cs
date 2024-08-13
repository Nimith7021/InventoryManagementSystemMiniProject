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
    internal class ProductStore
    {
        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nWelcome to the Product Application\n" +
                        "Which Operation do you wish to perform\n" +
                        "1.Add a new Product\n" +
                        "2.Update product Details\n" +
                        "3.Delete a Product\n" +
                        "4.View product Details\n" +
                        "5.View all products\n" +
                        "6.Exit\n"
                        );
                try
                {
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch (ExistingNameException ene)
                {
                    Console.WriteLine(ene.Message);
                }
                catch (ProductNotExistException pne)
                {
                    Console.WriteLine(pne.Message);
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void DoTask(int choice)
        {
            switch (choice) {

                case 1:
                    AddProduct();
                    break;
                case 2:
                    Update();
                    break;
                case 3:
                    Delete();
                    break;
                case 4:
                    ProdDetails(); 
                    break;
                case 5:
                    Display();
                    break;
                case 6:
                    InventoryStore.InventoryMenu();
                    break;
                default:
                    Console.WriteLine("Enter a valid input");
                    break;



            }

        }

        public static void AddProduct()
        {
            
            Console.WriteLine("Enter the product name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the product Description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the product quantity");
            int quantity = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter the price of Product");
            double price = Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("Enter the inventory id");
            int inventoryId = Convert.ToInt32( Console.ReadLine());
            ProductManagement.AddNewProduct(name, description, quantity, price,inventoryId);
            Console.WriteLine("Product Added Successfully");
        }

        public static void Display()
        {
            var products = ProductManagement.DisplayAllProducts();
            products.ForEach(product => Console.WriteLine(product));
        }

       
        
        public static void Update()
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Enter the name of Product");
            string name = Console.ReadLine();
            ProductManagement.UpdateProductDetails(id,name);
        }

        public static void Delete()
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32(Console.ReadLine());
            ProductManagement.DeleteProduct(id);
            Console.WriteLine("Product Deleted Successfully");
        }
        public static void ProdDetails()
        {
            Console.WriteLine("Enter the id");
            int id = Convert.ToInt32( Console.ReadLine());
            Product product = ProductManagement.ProductDetails(id);
            Console.WriteLine(product);
        }


    }
}
