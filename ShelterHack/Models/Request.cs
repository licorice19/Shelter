using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class Request
    {
        public int Id { get; set; }
        public Contract Contract { get; set; }
        public Shelter DeclarantShelter { get; set; }
        public DateTime DateTime { get; set; }
    }
}
