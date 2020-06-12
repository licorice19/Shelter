using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterHack.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ArrivedInShelter { get; set; }
        public Shelter ShelterContainer { get; set; }
        public string Photo { get; set; }
        public CatchServiceEmployee Catcher { get; set; }
    }
}
