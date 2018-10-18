using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using WebPetShop.Models.Animals;
using WebPetShop.Models.Orders;
using WebPetShop.Models.People;
using WebPetShop.Models.Utils;
using AppContext = WebPetShop.Generic.AppContext;

namespace WebPetShop.Controllers
{
    public class OrdersController : Controller
    {
        protected OrderManager orderManager;
        protected PersonManager personManager;
        protected AnimalManager animalManager;

        private string User = "Uadmin";

        public OrdersController(AppContext context)
        {
            orderManager = new OrderManager(context);
            personManager = new PersonManager(context);
            animalManager = new AnimalManager(context);
        }

        // GET: Orders
        public ActionResult Index()
        {
            List<Order> Orders = new List<Order>();
                
            Orders = orderManager.GetAll();

            if(Orders != null)
                return View(Orders);

            return RedirectToAction("Create");
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            Order order = new Order();
           
            if(id > 0)
            {
                order = orderManager.GetById(id);

                if(order.Itens!= null)
                {
                    if (order.Itens.Count > 0)
                    {
                        for(int i=0; i<= order.Itens.Count-1; i++)
                        {
                            if(order.Itens[i].AnimalId > 0)
                            {
                                order.Itens[i].Animal = animalManager.GetById(order.Itens[i].AnimalId);
                            }
                        }
                    }
                }

                return View(order);
            }
            else
            {
                return View();
            }
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            Order order = new Order();
            List<EntityUtil> types = new List<EntityUtil>();
            List<Person> people = new List<Person>();

            types.Add(new EntityUtil(0,null));
            //types.Add(new EntityUtil(1,"Venda"));
            types.Add(new EntityUtil(2,"Adoção"));

            ViewBag.TypeOrder = types;

            order.Total = 0;

            people = personManager.GetAll();

            people.Insert(0, new Person { Id = 0, Name = ""});

            if (people != null)
                ViewBag.People = people;
            
            return View(order);
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(Order order)
        {
            try
            {
                if(order.Person.Id == 0)
                {
                    order.Person = personManager.GetById(order.PersonId);
                }

                order.AddDate = DateTime.Now;
                order.AddUser = User;
                order.Situation = "A";

                //-- using for testing
                //order.Id = 1;
                //order = orderManager.GetByName(order.Person.Name);

                if (orderManager.Insert(order) == true)
                {
                    order = orderManager.GetByName(order.Person.Name);
                }

                return RedirectToAction("Itens", order);
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Itens(Order order)
        {
            List<EntityUtil> animalTypes = new List<EntityUtil>();

            animalTypes.Add(new EntityUtil(0, null));
            animalTypes.Add(new EntityUtil(1, "Cachorro"));
            animalTypes.Add(new EntityUtil(2, "Coelho"));
            animalTypes.Add(new EntityUtil(3, "Gato"));
            animalTypes.Add(new EntityUtil(4, "Pássaro"));
            animalTypes.Add(new EntityUtil(5, "Peixe"));

            ViewBag.AnimalType = animalTypes;

            if (order.Itens.Count == 0)
            {
                order = orderManager.GetById(order.Id);

                if(order.Itens!= null)
                {
                    if (order.Itens.Count > 0)
                    {
                        for (int i = 0; i <= order.Itens.Count - 1; i++)
                        {
                            if (order.Itens[i].AnimalId > 0)
                            {
                                order.Itens[i].Animal = animalManager.GetById(order.Itens[i].AnimalId);
                            }
                        }
                    }
                }

            }

            if (order.Type == 1)
                ViewBag.Type = "Venda";
            else if(order.Type == 2)
                ViewBag.Type = "Adoção";

            ViewBag.Order = order;
            ViewBag.PersonName = order.Person.Name;

            TempData["Order"] = order;

            OrderItem item = new OrderItem();
            item.OrderId = order.Id;
            item.Amount = 1;
            item.Price = 0;
            item.PriceUnit = 0;

            if ((!string.IsNullOrEmpty(order.Type.ToString())) && (order.Type > 0))
            {
                item.OrderType = order.Type;
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult AddItem(OrderItem item)
        {
            Order order = new Order();
            
            item.Animal = animalManager.GetById(item.AnimalId);

            order = orderManager.GetById(item.OrderId);

            if(order.Type > 0)
            {
                item.OrderType = order.Type;
                order.Itens.Add(item);
            }

            orderManager.InsertItem(item.OrderType,item);

            return RedirectToAction("Itens", order);
        }

        public JsonResult GetAnimalAdoptionByType(int ddlAnimalType)
        {
            List<Animal> anaimals = new List<Animal>();

            anaimals = animalManager.GetAnimalAdoptionByType(ddlAnimalType);
            anaimals.Insert(0, new Animal { Id = 0, Specie = "" });

            return Json(new SelectList(anaimals,"Id", "Specie"));
        }
        
        
        public ActionResult CloseOrder(int orderId)
        {
            Order order = new Order();

            if (orderId > 0)
            {
                order = orderManager.GetById(orderId);
                
                if((order.Itens != null) && (order.Itens.Count > 0))
                {
                    order.Situation = "F";
                    order.EditDate = DateTime.Now;
                    order.EditUser = User;

                    for (int i = 0; i <= order.Itens.Count - 1; i++)
                    {
                        if (order.Itens[i].AnimalId > 0)
                        {
                            order.Itens[i].Animal = animalManager.GetById(order.Itens[i].AnimalId);
                            order.Itens[i].Animal.Amount = order.Itens[i].Animal.Amount - order.Itens[i].Amount;
                            order.Itens[i].Animal.EditDate = order.EditDate;
                            order.Itens[i].Animal.EditUser = User;

                            animalManager.Update(order.Itens[i].Animal);
                        }
                    }

                    orderManager.Update(order);

                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Itens", order);
                }

            }

            return View();
        }

    }
}
