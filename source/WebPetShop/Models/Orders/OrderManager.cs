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
namespace WebPetShop.Models.Orders
{
    public class OrderManager : IManager<Order>
    {
        Manager<Order> manager;

        public OrderManager(AppContext context)
        {
            manager = new Manager<Order>(context);
        }

        public List<Order> GetAll()
        {
            List<Order> Orders = manager.db.Order.Include("Person").OrderBy(l => l.AddDate).ToList();

            if(Orders.Count > 0)
            {
                List<OrderItem> Itens = new List<OrderItem>();

                for(int i=0; i <= Orders.Count-1; i++)
                {
                    var id = Orders[i].Id;
                    Itens = manager.db.OrderItem.Where(o => o.OrderId == id).ToList();

                    if(Itens.Count > 0)
                    {
                        Orders[i].Itens = Itens;
                    }
                }

                return Orders;
            }
            else
            {
                return null;
            }
        }

        public Order GetById(int id)
        {
            Order order = new Order();

            if (id > 0)
            {
                order = manager.db.Order.Include("Person").Where(o => o.Id == id).FirstOrDefault();

                if(order.Itens.Count == 0)
                {
                    List<OrderItem> Itens = new List<OrderItem>();

                    var idorder = order.Id;
                    Itens = manager.db.OrderItem.Where(o => o.OrderId == idorder).ToList();

                    if (Itens.Count > 0)
                    {
                        order.Itens = Itens;
                    }
                }

                return order;
            }
            else
            {
                return null;
            } 
        }

        public Order GetByName(string name)
        {
            Order order = new Order();

            if (!string.IsNullOrEmpty(name))
            {
                order = manager.db.Order.Include("Person").Where(o => o.Person.Name.Contains(name)).FirstOrDefault();

                if (order.Itens.Count == 0)
                {
                    List<OrderItem> Itens = new List<OrderItem>();

                    var idorder = order.Id;
                    Itens = manager.db.OrderItem.Where(o => o.OrderId == idorder).ToList();

                    if (Itens.Count > 0)
                    {
                        order.Itens = Itens;
                    }
                }

                return order;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(Order order)
        {
            if((!string.IsNullOrEmpty(order.Type.ToString())) && (order.Person.Id > 0) &&
               (!string.IsNullOrEmpty(order.Total.ToString())) && (order.AddDate != null)&&
               (!string.IsNullOrEmpty(order.AddUser))
              )
            {
                if(order.Type == 1)
                {
                    order.Total = 0;
                }

                manager.Create(order);
                return true;
            }
            else
            {
                throw new Exception("Parameter invalid when inserting!");
            }
        }

        public bool Update(Order order)
        {
            if((order.Id > 0) &&
               (!string.IsNullOrEmpty(order.Type.ToString())) && (order.Person.Id > 0) &&
               (!string.IsNullOrEmpty(order.Total.ToString())) && (order.EditDate != null) &&
               (!string.IsNullOrEmpty(order.EditUser))
              )
            {
                manager.Change(order);
                return true;
            }
            else
            {
                throw new Exception("Parameter invalid when updating!");
            }
        }

        public bool Delete(Order order)
        {
            if(order.Id > 0)
            {
                if(order.Itens.Count > 0)
                {
                    var qitens = order.Itens.Count;
                    for(int i=0; i<= qitens-1; i++)
                    {
                        this.DeleteItem(order.Itens[i]);
                    }
                }

                manager.Remove(order);
                return true;
            }
            else
            {
                throw new Exception("Parameter invalid when deleting!");
            }
        }

        public void InsertItem(int type,OrderItem item)
        {
            try
            {
                Boolean validate = false;

                if((!string.IsNullOrEmpty(type.ToString())) && (item.OrderId > 0) && 
                   (!string.IsNullOrEmpty(item.Price.ToString())) && (item.Amount > 0)
                  )
                {
                    if(type == 1)
                    {
                        //intended for sale more, product no created.
                    }
                    else if (type == 2)
                    {
                        if (item.AnimalId > 0)
                        {
                            item.Price = 0;
                            item.PriceUnit = 0;
                            validate = true;
                        }
                    }

                    if(validate == true)
                    {
                        manager.db.Set<OrderItem>().Add(item);
                        manager.Save();
                    }
                   
                }
                else
                {
                    throw new Exception("Parameter invalid when inserting item!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Warning: An exception occurred while Insert the Itens record! " + ex.Message);
            }
        }

        public void UpdateItem(int type, OrderItem item)
        {
            try
            {
                Boolean validate = false;

                if((item.Id> 0) &&
                   (!string.IsNullOrEmpty(type.ToString())) && (item.OrderId > 0) &&
                   (!string.IsNullOrEmpty(item.Price.ToString())) && (item.Amount > 0)
                  )
                {
                    if (type == 1)
                    {
                        //intended for sale more, product no created.
                    }
                    else if (type == 2)
                    {
                        if (item.AnimalId > 0)
                        {
                            item.Price = 0;
                            item.PriceUnit = 0;
                            validate = true;
                        }
                    }

                    if (validate == true)
                    {
                        if (manager.db.Entry<OrderItem>(item).State == EntityState.Detached)
                        {
                            manager.db.Set<OrderItem>().Attach(item);
                        }

                        manager.db.Entry<OrderItem>(item).State = EntityState.Modified;
                        manager.Save();
                    }

                }
                else
                {
                    throw new Exception("Parameter invalid when inserting item!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Warning: An exception occurred while update the Itens record! " + ex.Message);
            }
        }

        public void DeleteItem(OrderItem item)
        {
            try
            {
                if(item.Id > 0)
                {
                    manager.db.Set<OrderItem>().Remove(item);
                    manager.Save();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Warning: An exception occurred while delete the Itens record! " + ex.Message);
            }
        }

    }
}