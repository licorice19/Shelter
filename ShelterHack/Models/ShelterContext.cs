using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShelterHack.Models
{
    public class ShelterContext : DbContext
    {
        public ShelterContext(DbContextOptions<ShelterContext> options)
            : base(options) { }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AuthData> AuthData { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<ShelterEmployee> ShelterEmployees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CatchServiceEmployee> CatchServiceEmployees { get; set; }
        public DbSet<CatchService> CatchServices { get; set; }
    }
}
