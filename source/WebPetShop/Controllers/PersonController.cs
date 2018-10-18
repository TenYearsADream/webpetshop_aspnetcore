using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using WebPetShop.Models.People;
using AppContext = WebPetShop.Generic.AppContext;

namespace WebPetShop.Controllers
{
    public class PersonController : Controller
    {
        protected PersonManager personManager;
        private string User = "Uadmin";

        public PersonController(AppContext context)
        {
            personManager = new PersonManager(context);
        }

        // GET: Person
        public ActionResult Index()
        {
            List<Person>People = personManager.GetAll();
            
            if(People != null)
                return View(People);

            return RedirectToAction("Create");
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var person = personManager.GetById(id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person person)
        {
            try
            {
                if (string.IsNullOrEmpty(person.Type.ToString()))
                {
                    if(person.SocialName == null || person.SocialName == "")
                    {
                        person.Type = 0;
                    }
                    else
                    {
                        person.Type = 1;
                    }
                }

                if(person.Type == 0)
                    person.Address.Type = 1;
                else
                    person.Address.Type = 0;
                
                person.AddDate = DateTime.Now;
                person.AddUser = User;

                person.Address.AddDate = person.AddDate;
                person.Address.AddUser = User;

                personManager.Insert(person);

                //Build person contacts
                if ((person.Phone != null) || (person.Cell != null) || (person.Mail != null))
                {
                    var auxperson = personManager.GetByName(person.Name);
                    Contact contact = null ;

                    if (person.Phone != null)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 0;
                        contact.Description = person.Phone;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.InsertContact(contact);
                    }

                    if (person.Cell != null)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 1;
                        contact.Description = person.Cell;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.InsertContact(contact);
                    }

                    if (person.Mail != null)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 2;
                        contact.Description = person.Mail;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.InsertContact(contact);
                    }

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == 0)
            {
                return StatusCode((int)HttpStatusCode.BadRequest);
            }

            var person = personManager.GetById(id);

            if(person.Contacts.Count > 0)
            {
                person.Phone = person.Contacts[0].Description;
                person.Cell = person.Contacts[1].Description;
                person.Mail = person.Contacts[2].Description;
            }

            if(person == null)
                return StatusCode((int)HttpStatusCode.NoContent);

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            try
            {
                Person paux = new Person();

                if (person.AddUser == null)
                {
                    paux = personManager.GetById(person.Id);
                    person.AddDate = paux.AddDate;
                    person.AddUser = paux.AddUser;
                    person.AddressId = paux.AddressId;
                }

                if (person.Type == 0)
                {
                    person.Address.Type = 2;
                }
                else if (person.Type == 1)
                {
                    person.Address.Type = 0;
                }

                if (person.Address.Id == 0)
                {
                    person.Address = personManager.GetAddressByName(person.Address.Name, person.Address.Number);
                    person.AddressId = person.Address.Id;
                }

                person.EditDate = DateTime.Now;
                person.EditUser = User;

                person.Address.EditDate = person.EditDate;
                person.Address.EditUser = User;

                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    personManager.Update(person);
                }

                //Change person contacts
                if ((person.Phone != null) || (person.Cell != null) || (person.Mail != null))
                {
                    var auxperson = personManager.GetByName(person.Name);
                    Contact contact = null;

                    if (person.Phone != null && person.Phone !=  auxperson.Contacts[0].Description)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 0;
                        contact.Description = person.Phone;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.UpdateContact(contact);
                    }

                    if (person.Cell != null && person.Cell != auxperson.Contacts[1].Description)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 1;
                        contact.Description = person.Cell;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.UpdateContact(contact);
                    }

                    if (person.Mail != null && person.Mail != auxperson.Contacts[2].Description)
                    {
                        contact = new Contact();

                        contact.PersonId = auxperson.Id;
                        contact.Type = 2;
                        contact.Description = person.Mail;
                        contact.AddDate = auxperson.AddDate;
                        contact.AddUser = auxperson.AddUser;

                        personManager.UpdateContact(contact);
                    }

                }

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var person = personManager.GetById(id);
            return View(person);
        }

        // Delete: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(Person person)
        {
            try
            {
                person = personManager.GetById(person.Id);

                if(person.Contacts.Count > 0)
                {
                    var qcontacs = person.Contacts.Count;

                    for(int i=0; i <= qcontacs-1; i++)
                    {
                        personManager.DeleteContact(person.Contacts[i]);
                    }
                }

                if (person.AddressId > 0)
                    personManager.DeleteAddress(person.Address);

                personManager.Delete(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Person/Find
        public ActionResult Find()
        {
            return View();
        }

        //POST: Person/Find/Ronaldo
        [HttpPost]
        public ActionResult Find(string name)
        {
            List<Person> list = personManager.GetByNameParameter(name);
            return View("Index", list);
        }
        
    }
}