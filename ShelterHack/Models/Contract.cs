using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Point { get; set; }
        public Shelter PerformerShelter { get; set; }
        public IEnumerable<Request> Requests { get; set; }
        public IEnumerable<Animal> CaughtAnimals { get; set; }
    }
}
