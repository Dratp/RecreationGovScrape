using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecreationGovScrape.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RecreationGovScrape.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            string APIKey = "afa5948d-c683-41b9-8a8c-d8c63006253c";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://ridb.recreation.gov/api/v1/");
            client.DefaultRequestHeaders.Add("apikey", APIKey);
            string[] activities = new string[] { "Canoeing", "Biking", "Fishing", "Hiking" };
            int offset = 0;


            var response = await client.GetAsync($"facilities?limit=50&offset={offset}&state=MI&activity={activities[0]}");
            RIDB data = await response.Content.ReadAsAsync<RIDB>();

            return View(data);

         }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
