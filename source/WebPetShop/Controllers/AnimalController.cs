using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using WebPetShop.Models.Animals;
using AppContext = WebPetShop.Generic.AppContext;

namespace WebPetShop.Controllers
{
    public class AnimalController : Controller
    {
        protected AnimalManager animalManager;
        private string User = "Uadmin";

        public AnimalController(AppContext context)
        {
            animalManager = new AnimalManager(context);
        }

        // GET: Animal
        public ActionResult Index()
        {
            List<Animal> Animals = new List<Animal>();

            Animals = animalManager.GetAll();

            if(Animals != null)
                return View(Animals);

            return RedirectToAction("Create");
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            var animal = animalManager.GetById(id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            try
            {
                if(animal.Price == null)
                {
                    animal.Price = 0;
                }

                animal.AddDate = DateTime.Now;
                animal.AddUser = User;

                if(animalManager.Insert(animal) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }

        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            var animal = animalManager.GetById(id);

            if(animal == null)
                return StatusCode((int)HttpStatusCode.NoContent);

            return View(animal);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(Animal animal)
        {
            try
            {
                Animal aaux = new Animal();
                
                if(animal.AddUser == null)
                {
                    aaux = animalManager.GetById(animal.Id);
                    animal.AddUser = aaux.AddUser;
                    animal.AddDate = aaux.AddDate;
                }

                animal.EditDate = DateTime.Now;
                animal.EditUser = User;
                
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    animalManager.Update(animal);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            var animal = animalManager.GetById(id);
            return View(animal);
        }

        // Delete: Animal/Delete/5
        [HttpPost]
        public ActionResult Deleted(int id)
        {
            try
            {
                var animal = animalManager.GetById(id);
                animalManager.Delete(animal);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Animal/Find
        public ActionResult Find()
        {
            return View();
        }

        // POST: Animal/Find/0/Buldogue
        [HttpPost]
        public ActionResult Find(Animal animal)
        {
            List<Animal>LstAnimals = new List<Animal>();

            if ((!string.IsNullOrEmpty(animal.Type.ToString())) && (!string.IsNullOrEmpty(animal.Specie))){
                LstAnimals = animalManager.GetAnimalByParamter(animal.Type, animal.Specie);    
            }

            return View("Index", LstAnimals);
        }
        
    }
}
