using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data
{
    // PizzaConbtext class that represents the db context. Inherits from the DbContext class.
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }
        public DbSet<ContosoPizza.Models.Pizza>? Pizzas { get; set; }
    }
}
