using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Models
{
    public class AnimalsContext:DbContext
    {
        public AnimalsContext() : base("AnimalsContext")
        {

        }
        public DbSet<Animal> Animals{ get; set; } //table Animals
        public DbSet<Breed> Breeds { get; set; }//table Breeds
    }
}
