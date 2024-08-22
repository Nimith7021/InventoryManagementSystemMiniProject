using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductQuantity { get; set; }

        public double ProductPrice { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }  

        public Product() { }    
        public Product(string productName, 
            string productDescription, int productQuantity, double productPrice,
            int invId,int productId=0)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            InventoryId = invId;
        }

        public override string ToString()
        {
            return $"--------------------------------------------------\n" +
                $"Product Id : {ProductId}\n" +
                $"Product Name : {ProductName}\n" +
                $"Product Description : {ProductDescription}\n" +
                $"Product Quantity : {ProductQuantity}\n" +
                $"Product Price : {ProductPrice}\n" +
                $"Inventory Id : {InventoryId}\n";
        }

        public static Product CreateProduct(string name, string description , int quantity , double price,int invId)
        {
            return new Product(name, description,quantity,price,invId);
        }


    }
}
