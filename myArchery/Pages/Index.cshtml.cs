﻿using Microsoft.AspNetCore.Mvc;
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
            Utility.SendEmail("myarchery.bslinz2@gmail.com", "Pichler du bist toll :)");
        }

        public void Test()
        {
            Console.WriteLine("Test");
        }
    }
}