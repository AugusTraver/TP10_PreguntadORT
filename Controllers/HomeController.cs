using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP10_AhorcadORT.Models;

namespace TP10_AhorcadORT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}
