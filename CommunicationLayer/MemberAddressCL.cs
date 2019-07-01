using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class MemberAddressCL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shippingAddress { get; set; }
        public string billingAddress { get; set; }
        public string permanentAddress { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string isDelete { get; set; }
        public string isGuest { get; set; }
        public string mobNo { get; set; }
        public string password { get; set; }
    }
}
