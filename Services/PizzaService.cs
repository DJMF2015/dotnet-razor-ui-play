using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    //  this class exposes the methods to list and delete, add pizza objects. Uses PizaContext to read and write pizzas to the database
    // registered for Dependecy Injection in Program.cs
    public class PizzaService
    {
        private readonly PizzaContext _context = default!;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public IList<Pizza> GetPizzas()
        {
            if (_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
        }

        public void DeletePizza(int id)
        {
            if (_context.Pizzas != null)
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }
        }
    }
}
