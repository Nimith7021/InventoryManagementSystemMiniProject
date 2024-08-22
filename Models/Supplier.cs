using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Models
{
    internal class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string Name { get; set; }

        public string ContactNumber { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public Supplier() { }   
        public Supplier(string name , string number,int invId,int id=0)
        {
            SupplierID = id;
            Name = name;
            ContactNumber = number;
            InventoryId = invId;

        }

        public static Supplier CreateSupplier(string name, string number,int invId)
        {
            return new Supplier(name,number,invId);
        }

        public override string ToString()
        {
            return $"+++++++++++++++++++++++++++++++++++++++++++\n" +
                $"Supplier Id : {SupplierID}\n" +
                $"Supplier Name : {Name}\n" +
                $"Supplier Contact : {ContactNumber}\n" +
                $"Inventory Id : {InventoryId}\n";
        }

    }
}
