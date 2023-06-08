using Animal11d.Controllers;
using Animal11d.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animal11d.Views
{
     class Display
    {
        private int closeOperationId = 6;
        private AnimalsLogic animalLogic = new AnimalsLogic();
        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            animalLogic.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Animal animal = animalLogic.Get(id);
            if (animal != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + animal.Id);
                Console.WriteLine("Name: " + animal.Name);
                Console.WriteLine("Age: " + animal.Age);
                Console.WriteLine("Stock: " + animal.BreedsId);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Animal animal = animalLogic.Get(id);
            if (animal != null)
            {
                Console.WriteLine("Enter name: ");
                animal.Name = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                animal.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter breedId: ");
                animal.BreedsId = int.Parse(Console.ReadLine());
                animalLogic.Update(id,animal);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Animal animal = new Animal();
            Console.WriteLine("Enter name: ");
            animal.Name = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            animal.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter breed: ");
            animal.BreedsId = int.Parse(Console.ReadLine());
            animalLogic.Create(animal);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PRODUCTS" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var products = animalLogic.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.Age, item.BreedsId);
            }
        }
    }
}
