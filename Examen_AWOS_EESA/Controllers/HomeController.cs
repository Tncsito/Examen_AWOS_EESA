using Examen_AWOS_EESA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Web.Script.Serialization;
using System.Text.Json;
using System.Net;

namespace Examen_AWOS_EESA.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            try
            {
                string _URL = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
                WebRequest req = WebRequest.Create(_URL);
                req.Method = "GET";
                req.ContentType = "application/json; charset=utf-8";
                WebResponse resp = req.GetResponse();
                Stream stream = resp.GetResponseStream();
                StreamReader re = new StreamReader(stream);
                string json = re.ReadToEnd();

                //APOD w = (APOD)new jav

                if(w != null)
                {
                    ViewBag.copyright = w.copiright;
                    ViewBag.date = w.date.ToString("dddd, dd MMMM yyyy"); ;
                    ViewBag.explanation = w.explanation;
                    ViewBag.hdurl = w.hdurl;
                    ViewBag.media_type = w.media_type;
                    ViewBag.service_version = w.service_version;
                    ViewBag.title = w.title;
                    ViewBag.url = w.url;
                }
                else
                {

                }
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
