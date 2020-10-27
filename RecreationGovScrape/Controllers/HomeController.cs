﻿using System;
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
using Dapper.Contrib.Extensions;
using System.Data;
using System.Data.SqlClient;
using Dapper;

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

            RIDB data = new RIDB();
            for (int i = 0; i<activities.Length; i++)
            {
                var response = await client.GetAsync($"facilities?limit=50&offset={offset}&state=MI&activity={activities[i]}");
                data = await response.Content.ReadAsAsync<RIDB>();
                LogInfo(data, activities[i]);
            }
            

            return View(data);

        }

        public void LogInfo(RIDB data, string act)
        {
            const string server = "Server=7RP7Q13\\SQLEXPRESS;Database=Recdit;user id=csharp;password=abc123";
            IDbConnection db = new SqlConnection(server);



            foreach (RECDATA rec in data.recData)
            {
                string name = rec.FacilityName.ToString();
                name.Replace("'", " ");
                

                db.Query($"insert into RIDB (FacilityID, FacilityName, FacilityTypeDescription, FacilityLongitude, FacilityLatitude, FacilityPhone, FacilityEmail) Values ('{rec.FacilityID}', '{name}', '{rec.FacilityTypeDescription}', '{rec.FacilityLongitude}', '{rec.FacilityLatitude}', '{rec.FacilityPhone}', '{rec.FacilityEmail}')");
                db.Query($"insert into RIDBAct (FacilityID, Activity) Values ('{rec.FacilityID}', '{act}')");
            }



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
