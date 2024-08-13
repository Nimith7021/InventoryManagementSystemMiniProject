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
    internal class SupplierManagement
    {
        static SupplierRepository repository = new SupplierRepository(new InventoryContext());
        public static void AddNewSupplier(string name , string contact,int inventoryId)
        {
            if (repository.CheckBySupplierName(name))
            {
                Supplier product = Supplier.CreateSupplier(name, contact,inventoryId);
                repository.AddSupplierDB(product);
            }
            else
            {
                throw new ExistingNameException("Supplier Name already Exists");
            }
        }



        

        public static List<Supplier> DisplayAllSuppliers()
        {
            var suppliers = repository.DisplaySupplierDB();
            return suppliers;
        }

        public static void UpdateSupplierDetails(int id, string name,string contact)
        {
            if (repository.CheckSupplierId(id))
            {
                if (repository.CheckBySupplierName(name))
                {
                    repository.UpdateDetails(id, name, contact);
                }
                else
                {
                    throw new ExistingNameException("Supplier Name Already Exists");
                }
            }
            else
            {
                throw new SupplierNotExistException("Supplier doesn't exist");
            }

        }

        public static Supplier SupplierDetails(int id)
        {
            if (repository.CheckSupplierId(id))
                return repository.SupplierDetails(id);
            else
                throw new SupplierNotExistException("Supplier doesn't exist");
        }

        public static void DeleteSupplier(int id)
        {
            if (repository.CheckSupplierId(id))
                repository.RemoveSupplierDB(id);
            else
                throw new SupplierNotExistException("Supplier doesn't exist");
        }
    }
}
