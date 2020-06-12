using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<ShelterEmployee> Employees { get; set; }
        public virtual IEnumerable<Animal> ContainingAnimals { get; set; }
        public virtual IEnumerable<Contract> PreformingContracts { get; set; }
    }
}
