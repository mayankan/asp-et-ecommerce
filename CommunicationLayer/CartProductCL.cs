using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class CartProductCL
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int cartId { get; set; }
        public int quantity { get; set; }
    }
}
