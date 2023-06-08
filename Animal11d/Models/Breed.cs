using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<Animal> Animals { get; set; }//1:M
    }
}
