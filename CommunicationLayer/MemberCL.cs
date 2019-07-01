using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class MemberCL
    {
        public int id { get; set; }
        public bool isGuest { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobNo { get; set; }
        public int addressId { get; set; }
        public bool gender { get; set; }
        public bool isDeleted { get; set; }
        public string password { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
