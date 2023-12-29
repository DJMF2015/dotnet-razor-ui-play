using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!; // this is the list of pizzas that will be displayed on the page

        public PizzaListModel(PizzaService service) //constructor
        {
            // hoilds a reference to a pizzaservice object 
            _service = service;
        }

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!; // this is the property that will hold the new pizza that will be added to the list

        public void OnGet() // this is the method to retrieve a list of pizzas from pizzaList property
        {
            PizzaList = _service.GetPizzas(); // this is the method that gets the list of pizzas from the database
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeletePizza(id);
            return RedirectToPage();
        }

    }
}
