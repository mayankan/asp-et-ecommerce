using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class AddressLocationCL
    {
        public int id { get; set; }
        public int stateId { get; set; }
        public int countryId { get; set; }
        public string cityName { get; set; }
        public string stateName { get; set; }
        public string countryName { get; set; }
    }
}
