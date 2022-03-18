using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using myArchery.Services;

namespace myArchery.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(EventService.GetAllPublicEvents().Startdate);
        }

        public void Test()
        {
            Console.WriteLine("Test");
        }
    }
}