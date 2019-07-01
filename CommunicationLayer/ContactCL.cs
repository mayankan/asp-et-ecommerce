using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class ContactCL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string emailId { get; set; }
        public string mobNo { get;set; }
        public int cityId { get; set; }
        public string query { get; set; }
        public DateTime dateAdded { get; set; }
    }
}
