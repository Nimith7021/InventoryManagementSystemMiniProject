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
    internal class SupplyStore
    {
       
        
            public static void DisplayMenu()
            {
            while (true)
            { 
                Console.WriteLine("\nWelcome to the Supplier Application\n" +
                        "Which Operation do you wish to perform\n" +
                        "1.Add a new Supplier\n" +
                        "2.Update Supplier Details\n" +
                        "3.Delete a Supplier\n" +
                        "4.View Supplier Details\n" +
                        "5.View all Supliers\n" +
                        "6.Exit\n"
                        );

                
               
                try
                {
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    DoTask(choice);
                }
                catch(ExistingNameException ene)
                {
                    Console.WriteLine(ene.Message);
                }
                catch(SupplierNotExistException sne)
                {
                    Console.WriteLine(sne.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            }

            static void DoTask(int choice)
            {
                switch (choice)
                {

                    case 1:
                        AddSupplier();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        SupplierDetails();
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

            public static void AddSupplier()
            {

                Console.WriteLine("Enter the supplier name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the Supplier Contact");
                string contact = Console.ReadLine();
                Console.WriteLine("Enter the inventory Id");
                int inventoryId = Convert.ToInt32(Console.ReadLine());            
                SupplierManagement.AddNewSupplier(name,contact,inventoryId);
                Console.WriteLine("Supplier Added Successfully");
            }

            public static void Display()
            {
                var suppliers = SupplierManagement.DisplayAllSuppliers();
                suppliers.ForEach(x => Console.WriteLine(x));
            }



            public static void Update()
            {
                Console.WriteLine("Enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name of Supplier");
                string name = Console.ReadLine();
                Console.WriteLine("Enter the contact of Supplier");
                string contact = Console.ReadLine();
                SupplierManagement.UpdateSupplierDetails(id, name,contact);
            }

            public static void Delete()
            {
                Console.WriteLine("Enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                SupplierManagement.DeleteSupplier(id);
                Console.WriteLine("Product Deleted Successfully");
            }
            public static void SupplierDetails()
            {
                Console.WriteLine("Enter the id");
                int id = Convert.ToInt32(Console.ReadLine());
                Supplier supplier = SupplierManagement.SupplierDetails(id);
                Console.WriteLine(supplier);
            }


        }
    }



