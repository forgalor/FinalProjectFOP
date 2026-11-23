using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPetaFOP
{
    public class OrderRecord
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderRecord(string username, string productName, int quantity)
        {
            Username = username;
            ProductName = productName;
            Quantity = quantity;
            OrderDate = DateTime.Now;
        }
    }
}
