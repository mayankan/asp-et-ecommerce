using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class BrandCL
    {
        public int id { get; set; }
        public string brandCode { get; set; }
        public string name { get; set; }
        public decimal promotions { get; set; }
        public int brandRating { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
        public string imageURL { get; set; }
    }
}
