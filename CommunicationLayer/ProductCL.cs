using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class ProductCL
    {
        public int Id { get; set; }
        public string productCode { get; set; }
        public int categoryId { get; set; }
        public int brandId { get; set; }
        public string featureDetails { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int stockQuantity { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
        public decimal weight { get; set; }
        public string keywordsMeta { get; set; }
        public int dispatchTime { get; set; }
        public bool codApplicable { get; set; }
        public decimal shippingCharge { get; set; }
        public string imageUrl { get; set; }
        public string warranty { get; set; }
        public string description { get; set; }
        public bool isHot { get; set; }
    }
}
