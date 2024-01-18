using BurakAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BurakAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hesapla(TarifeHesaplayiciModel model)
        {
            try
            {
                double mesafe = GetDistanceAsync(model.BaslangicAdres, model.VarisAdres).Result;

                model.Mesafe = mesafe * 1.2;

                return View("Index", model);
            }     
            catch (Exception ex)
            {
                model.HataMesaji = $"Hata: {ex.Message}";
                return View("Index", model);
            }
        }


        private string apiKey = "[YOURKEY]";
        private const string apiUrl = "https://maps.googleapis.com/maps/api/directions/json";


        public async Task<double> GetDistanceAsync(string origin, string destination)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={origin}&destinations={destination}&key={apiKey}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<DistanceMatrixResponse>(json); 

                    if (result != null && result.Rows.Length > 0 && result.Rows[0].Elements.Length > 0)
                    {
                        double distanceInMeters = result.Rows[0].Elements[0].Distance.Value;

                        double distanceInKilometers = distanceInMeters / 1000;

                        return distanceInKilometers;
                    }
                }

                throw new Exception("Error while fetching distance from Google Maps API.");
            }
        }

        public IActionResult GetDistance(string origin, string destination)
        {
            double distance = GetDistanceAsync(origin, destination).Result;

            ViewBag.hesapla = distance;

            return View("Index");
        }
        public class DistanceMatrixResponse
        {
            public Row[] Rows { get; set; }
        }

        public class Row
        {
            public Element[] Elements { get; set; }
        }

        public class Element
        {
            public Distance Distance { get; set; }
        }

        public class Distance
        {
            public double Value { get; set; }
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