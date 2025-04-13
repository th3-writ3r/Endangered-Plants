using EndangerPlantApp.Data.Entities;
using EndangerPlantApp.DTOs;
using EndangerPlantApp.Models;
using EndangerPlantApp.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace EndangerPlantApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlantServices _plantServices;

        public HomeController(ILogger<HomeController> logger, IPlantServices plantServices)
        {
            _logger = logger;
            _plantServices = plantServices;
        }

        public async Task<IActionResult> Index()
        {
            StringBuilder sb = new StringBuilder();
            var plants = await _plantServices.GetAllAsync();
            foreach ( var plant in plants )
            {
                sb.AppendLine($"{{ lat: {plant.Lat}, lng: {plant.Long} }},");
            }
            ViewData["Plants"] = sb.ToString();
            return View();
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