using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class Request
    {
        public int Id { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Shelter DeclarantShelter { get; set; }
        public DateTime DateTime { get; set; }
    }
}
