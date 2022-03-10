using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        }

        [HttpPost]
        public void Test()
        {
            Console.WriteLine("Test");
        }

        public ActionResult Test(int id)
        {
            Console.WriteLine("Test");

            return ReturnToAction("Index");
        }
    }
}