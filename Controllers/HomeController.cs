using Confluent.Kafka;
using Newtonsoft.Json;
using ShopifyFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopifyFrontEnd.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string searchTerm)
        {

            return View();
        }

        public ActionResult Search(string searchTerm)
        {
            Root r = null;

            if (Request.IsAjaxRequest())
            {
                if (searchTerm != null)
                {
                    WebClient client = new WebClient();
                    string reply = client.DownloadString("http://www.omdbapi.com/?s=" + searchTerm + "&apikey=" + ConfigurationManager.AppSettings["Key"]);
                    r = JsonConvert.DeserializeObject<Root>(reply);
                }
            }

            ViewData["SearchTerm"] = searchTerm;

            return PartialView("_SearchResults", r);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}