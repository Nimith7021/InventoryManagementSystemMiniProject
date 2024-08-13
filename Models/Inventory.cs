using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystem.Controller;

namespace InventoryManagementSystem.Models
{
    internal class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        public string Location { get; set; }
        public List<Product> products { get; set; }

        public List<Supplier> suppliers { get; set; }   

        public List<TransactionStock> transactionStocks { get; set; }

        public Inventory() { }
        public Inventory(int id , string loc)
        {
            InventoryId = id;
            Location = loc;
        }
        public override string ToString()
        {
            return $"   InventoryId - {InventoryId} Location - {Location}         ";
        }


    }
}
