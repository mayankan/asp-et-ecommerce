using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class OrderGridCL
    {
        public int id { get; set; }
        public string orderNumber { get; set; }
        public string orderStatus { get; set; }
        public string productName { get; set; }
        public string productQty { get; set; }
        public string shippingCharge { get; set; }
        public string taxAmt { get; set; }
        public string totalAmt { get; set; }
        public string memberName { get; set; }
        public string address { get; set; }
        public string addressType { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public int cityId { get; set; }
        public int stateId { get; set; }
        public string country { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public string shippingDescription { get; set; }
        public bool isDeleted { get; set; }
    }
}
