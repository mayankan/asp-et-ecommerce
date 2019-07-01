using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class OrderCL
    {
        public int id { get; set; }
        public string orderNumber { get; set; }
        public int cartId { get; set; }
        public int addressId { get; set; }
        public int statusId { get; set; }
        public string totalAmount { get; set; }
        public string shippingCharge { get; set; }
        public string taxAmount { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
    }
}
