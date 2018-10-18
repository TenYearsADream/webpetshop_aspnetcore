using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPetShop.Generic;
using AppContext = WebPetShop.Generic.AppContext;


/*--------------------------------------
 * Project.......: WebPetShop
 * Author........: Ronaldo Torre
 * Date..........: Oct/2018
 * --------------------------------------
 */
namespace WebPetShop.Models.Animals
{
    public class AnimalManager : IManager<Animal>
    {
        Manager<Animal> manager;

        public AnimalManager(AppContext context)
        {
            manager = new Manager<Animal>(context);
        }

        public List<Animal> GetAll()
        {
            List<Animal> Animals = manager.db.Animal.OrderBy(o => o.Type).ToList();

            if(Animals.Count > 0)
            {
                return Animals;
            }
            else
            {
                return null;
            }
        }

        public Animal GetById(int id)
        {
            return manager.db.Animal.Where(a => a.Id == id).FirstOrDefault();
        }

        public Animal GetByName(string name)
        {
            return manager.db.Animal.Where(a => a.Specie.Contains(name)).FirstOrDefault();
        }

        public List<Animal> GetAnimalByParamter(int type, string breed)
        {
            return manager.db.Animal.Where(t => t.Type == type).Where(b => b.Specie.StartsWith(breed)).OrderBy(a => a.Type).ToList();
        }

        public List<Animal> GetAnimalAdoptionByType(int animalType)
        {
            return manager.db.Animal.Where(t => t.Type == animalType).Where(v => v.Price == 0).OrderBy(a => a.Specie).ToList();
        }

        public bool Insert(Animal animal)
        {
            if ((!string.IsNullOrEmpty(animal.Type.ToString())) &&(animal.AddDate != null)&&(animal.AddUser != null))
            {
                manager.Create(animal);
                return true;
            }
            else
            {
                throw new Exception("Parameter invalid when inserting!");
            }
        }

        public bool Update(Animal animal)
        {
            if ((animal.Id > 0) &&
                (!string.IsNullOrEmpty(animal.Type.ToString())) &&
                (animal.EditDate != null) && (animal.EditUser != null)
               )
            {
                manager.Change(animal);
                return true;
            }
            else
            {
                throw new Exception("Parameter invalid when updating!");
            }
        }

        public bool Delete(Animal animal)
        {
            if (animal.Id > 0)
            {
                manager.Remove(animal);
                return true;
            }
            else
            {
                throw new Exception("Warning: An error occurred while trying to delete the record!");
            }
        }
    }
}