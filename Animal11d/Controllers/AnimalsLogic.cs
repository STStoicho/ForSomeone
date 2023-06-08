using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Controllers
{
    public class AnimalsLogic
    {
        private AnimalsContext _animalsDbContext = new AnimalsContext();//Database
        public List<Animal> GetAll()
        {
            return _animalsDbContext.Animals.Include("Breeds").ToList();
        }

        public Animal Get(int id)
        {
            Animal findedAnimal = _animalsDbContext.Animals.Find(id);
            if (findedAnimal != null)
            {
                _animalsDbContext.Entry(findedAnimal).Reference(x => x.Breeds).Load();
            }
            return findedAnimal;

        }


        public void Create(Animal animal)
        {
            _animalsDbContext.Animals.Add(animal);
            _animalsDbContext.SaveChanges();
        }

        public void Update(int id, Animal animal)
        {
            Animal findedAnimal = _animalsDbContext.Animals.Find(id);
            if (findedAnimal == null)
            {
                return;
            }
            findedAnimal.Name = animal.Name;
            findedAnimal.Age = animal.Age;
            findedAnimal.Description = animal.Description;
            findedAnimal.BreedsId = animal.BreedsId;
            _animalsDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Animal findedAnimal= _animalsDbContext.Animals.Find(id);
            _animalsDbContext.Animals.Remove(findedAnimal);
            _animalsDbContext.SaveChanges();
        }


    }
}
