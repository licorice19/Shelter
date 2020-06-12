using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class CatchServiceEmployee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Animal> CaughtAnimals { get; set; }
        public AuthData AuthData { get; set; }
    }
}
