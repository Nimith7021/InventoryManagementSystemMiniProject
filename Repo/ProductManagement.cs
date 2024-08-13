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
    internal class ProductManagement
    {
        static public ProductRepository repository = new ProductRepository(new InventoryContext());
        public static void AddNewProduct(string name, string description,
           int quantity, double price,int inventoryId)
        {
            if (repository.CheckByProductName(name))
            {
                Product product = Product.CreateProduct(name, description,
                    quantity, price,inventoryId);
                repository.AddProductDB(product);
            }
            else
            {
                throw new ExistingNameException("Name already Exists");
            }
        }



        

        public static List<Product> DisplayAllProducts()
        {
            var products = repository.DisplayProductDB();
            return products;
        }

        public static void UpdateProductDetails(int id, string name)
        {

            if (repository.CheckProductId(id))
            {
                if (repository.CheckByProductName(name))
                {
                    repository.UpdateDetails(name, id);
                }
                else
                {
                    throw new ExistingNameException("Name already Exists");
                }
            }
            else
            {
                throw new ProductNotExistException("Product doesn't exist");
            }
            
        }

        public static Product ProductDetails(int id)
        {
            if (repository.CheckProductId(id))
                return repository.ProductDetails(id);
            else
                throw new ProductNotExistException("Product doesn't exist");
        }

        public static void DeleteProduct(int id)
        {
            if (repository.CheckProductId(id))
                repository.RemoveProductDB(id);
            else
                throw new ProductNotExistException("Product doesn't exist");
        }
    }
}
