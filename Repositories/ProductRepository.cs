using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Exceptions;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories
{
    internal class ProductRepository
    {
        private readonly InventoryContext _context;
        public ProductRepository(InventoryContext context)
        {
            _context = context;
        }

        public List<Product> DisplayProductDB()
        {
            return _context.Products.ToList();
        }

        public void AddProductDB(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void RemoveProductDB(int id) { 
            var productToDelete = _context.Products.
                Where(product=>product.ProductId==id).FirstOrDefault();
            if (productToDelete != null) {

                _context.Remove(productToDelete);
                _context.SaveChanges();
            }
            else
            {
                
            }
            
        }

        public void UpdateDetails(string name,int id)
        {
            var findProduct = _context.Products.Where(product => product.ProductId == id).FirstOrDefault();
            findProduct.ProductName = name;
            _context.Products.Update(findProduct);
            _context.SaveChanges();
        }

        public Product ProductDetails(int id)
        {
            var product = _context.Products.
                Where(product => product.ProductId == id).FirstOrDefault();
            return product;
        }

        public bool CheckByProductName(string name)
        {
            var products = _context.Products.Where(product=>product.ProductName==name).FirstOrDefault();
            return products == null;
        }

        public bool CheckProductId(int id)
        {
            var products = _context.Products.Where(product => product.ProductId == id).FirstOrDefault();
            return products != null;
        }

        public void AddStockItems(int id ,int quantity,int inventoryId)
        {
            var products = _context.Products.Where(product => product.ProductId == id).FirstOrDefault();
            products.ProductQuantity += quantity;
            _context.Products.Update(products);
            _context.transactions.Add(new TransactionStock(id,"Stock Added",quantity,DateTime.Now,inventoryId));
            _context.SaveChanges();

        }

        public void RemoveStockItems(int id, int quantity,int inventoryId)
        {
            var products = _context.Products.Where(product => product.ProductId == id).FirstOrDefault();
            if (products.ProductQuantity - quantity < 0)
            {
                throw new NegativeStockException("Stock Quantity cannot be negative");
            }
            else
            {
                products.ProductQuantity -= quantity;
                _context.Products.Update(products);
                _context.transactions.Add(new TransactionStock(id, "Stock Removed", quantity, DateTime.Now,inventoryId));
                _context.SaveChanges();
            }

        }
    }
}
