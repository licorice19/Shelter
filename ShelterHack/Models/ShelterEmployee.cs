using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class ShelterEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual AuthData AuthData { get; set; }
        public virtual IEnumerable<Animal> CaughtAnimals { get; set; }
        public virtual Shelter Shelter { get; set; }
    }
}
