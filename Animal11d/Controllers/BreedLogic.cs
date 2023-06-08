using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Controllers
{
    public class BreedLogic
    {
        private AnimalsContext _animalsDbContext = new AnimalsContext();

        public List<Breed> GetAllBreeds()
        {
            return _animalsDbContext.Breeds.ToList();
        }

        public string GetBreedById(int id)
        {
            return _animalsDbContext.Breeds.Find(id).Name;
        }
    }
}
