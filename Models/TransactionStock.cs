using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InventoryManagementSystem.Models
{
    internal class TransactionStock
    {
        [Key]
        public int TransactionID { get; set; }

        public int ProductID { get; set; }
        public string Type { get; set; }
        public int Quantity {  get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("Inventory")]
        public int? InventoryId { get; set; }

        public TransactionStock() { }
        public TransactionStock(int id , string type , int quantity , DateTime date,int invId)
        {
            ProductID = id;
            Type = type;
            Quantity = quantity;
            Date = date;
            InventoryId = invId;
        }

       
        public override string ToString()
        {
            return $"**********************************************\n" +
                   $"Transaction ID : {TransactionID}\n" +
                   $"Product ID : {ProductID}\n" +
                   $"Type : {Type}\n" +
                   $"Quantity : {Quantity}\n" +
                   $"Date : {Date}\n" +
                $"*************************************************\n";
        }
    }
}
