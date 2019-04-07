using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockWebApp.Models;
// ADD THESE DIRECTIVES
using StockWebApp.DataAccess;
using Newtonsoft.Json;
using System.Net.Http;
using static StockWebApp.Models.EF_Models;

namespace StockWebApp.Controllers
{
    public class NewsController : Controller
    {
        /*
            These lines are needed to use the Database context,
            define the connection to the API, and use the
            HttpClient to request data from the API
        */
        public ApplicationDbContext dbContext;
        //Base URL for the IEXTrading API. Method specific URLs are appended to this base URL.
        string BASE_URL = "https://api.iextrading.com/1.0/";
        HttpClient httpClient;

        /*
           These lines create a Constructor for the HomeController.
           Then, the Database context is defined in a variable.
           Then, an instance of the HttpClient is created.
      */
        public NewsController(ApplicationDbContext context)
        {
            dbContext = context;

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new
                System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*
            Calls the IEX reference API to get the list of news data.
            Returns a list of the news whose information is available. 
        */
        public List<NewsData> GetNews()
        {
            string IEXTrading_API_PATH = BASE_URL + "stock/market/news/last/10";
            string newsList = "";
            List<NewsData> newsInfo = null;

            // connect to the IEXTrading API and retrieve information
            httpClient.BaseAddress = new Uri(IEXTrading_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(IEXTrading_API_PATH).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                newsList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            // now, parse the Json strings as C# objects
            if (!newsList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                newsInfo = JsonConvert.DeserializeObject<List<NewsData>>(newsList);
            }

            return newsInfo;
        }

        public IActionResult News()
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessComp = 0;
            List<NewsData> news = GetNews();

            //Save companies in TempData, so they do not have to be retrieved again
            TempData["News"] = JsonConvert.SerializeObject(news);

            return View(news);
        }
        /*
            Save the available symbols in the database
        */
        public IActionResult PopulateNews()
        {
            // Retrieve the ews that were saved in the news method
            List<NewsData> newsInfo = JsonConvert.DeserializeObject<List<NewsData>>(TempData["News"].ToString());

            foreach (NewsData newsRow in newsInfo)
            {
                dbContext.News.Add(newsRow);
            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("News", newsInfo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
