using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class CartCL
    {
        public int id { get; set; }
        public int memberId { get; set; }
        public DateTime dateAdded { get; set; }
        public string shippingCost { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
    }
}
