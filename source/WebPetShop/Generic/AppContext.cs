using Microsoft.EntityFrameworkCore;
using WebPetShop.Models.People;
using WebPetShop.Models.Animals;
using WebPetShop.Models.Orders;

namespace WebPetShop.Generic
{
    /*--------------------------------------
     * Project.......: WebPetShop
     * Author........: Ronaldo Torre
     * Date..........: Oct/2018
     * --------------------------------------
     */
    public class AppContext: DbContext
    {
        public AppContext() { }

        public AppContext(DbContextOptions<AppContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder) { }
               
        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }

    }
}