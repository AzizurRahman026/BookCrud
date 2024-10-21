using System.Collections.Specialized;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service;
using ServiceContracts;
using ServiceContracts.DTO;

namespace bookCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IBookCountService bookCountServices;
        

        public HomeController(IBookCountService bookCountService)
        {
            bookCountServices = bookCountService;
        }

        // Index page
        [HttpGet("/")]
        public IActionResult Index()
        {
            Log.Information("\n\nBook Home Page Test...\n");
            return Ok("Home Page");
        }

        // Name formatting
        [HttpPost("/name")]
        public IActionResult Name(string? name)
        {
            Console.WriteLine("Coming Name through API: " + name);
            return Ok(name);
        }

        // API to add a certain number of books
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] AddBookRequest book)
        {
            if (book.numberOfBook > 0)
            {
                bookCountServices.addBook(book);
                return Ok($"{book.numberOfBook} books added successfully.");
            }
            return BadRequest("The number of books to add must be greater than 0.");
        }

        // API to remove a certain number of books
        [HttpDelete("remove-book")]
        public IActionResult RemoveBook([FromBody] removeBook info)
        {

            // Console.WriteLine($"Book id: {info.id}\nBook count: {info.count}\n");
            if (info.count > 0)
            {
                var cnt = bookCountServices.removeBook(info);
                return Ok($"{cnt} books removed successfully.");
            }
            return BadRequest("The number of books to remove must be greater than zero.");
        }

        // API to count the current number of books
        [HttpGet("countcurrentbook")]
        public IActionResult CountCurrentBook()
        {
            var currentAvailableBook = bookCountServices.currentBook();
            // Console.WriteLine($"current AvailableBook...{currentAvailableBook}");
            return Ok($"Current No of Books: {currentAvailableBook}");
        }
    }
}






/*using Microsoft.AspNetCore.Mvc;
using ServiceContracts.DTO;
using ServiceContracts;

namespace BookCrudTestApplication.Controllers
{
    public class HomeController : Controller
    {
        public ICountryServices CountryServices;

        public HomeController(ICountryServices countryServices)
        {
            CountryServices = countryServices;
        }

        [HttpPost("add-country")]
        public IActionResult AddStudent(CountryAddRequest countryAddRequest)
        {
            var country = CountryServices.AddCountry(countryAddRequest);
            return Ok(country);
        }
    }
}*/
