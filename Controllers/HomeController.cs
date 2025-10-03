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

    public IActionResult ConfigurarJuego()
    {
        ViewBag.categoria = BD.ObtenerCategorias();
        return View("ConfiguarJuego");
    }
    [HttpPost]
    public IActionResult Comenzar(string username, int categoria)
    {
        HttpContext.Session.SetString("Jueg", Juego);
        Juego Juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Jueg"));

        Juego.CargarPartida(username, categoria);
        HttpContext.Session.SetString("juego", Juego);

        return RedirectToAction("Jugar");
    }
    [HttpPost]
    public IActionResult Jugar()
    {

        Juego Juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Jueg"));
        
        ViewBag.consigna = Juego.PreguntaActual.Enunciado;
        ViewBag.Foto = Juego.PreguntaActual.Foto;
        if (Juego.ListaPreguntas.Count == 0)
        {
           HttpContext.Session.SetString("juego", Juego);
            return View("Fin");
        }
        else
        {
            ViewBag.ListaRespuestas = Juego.ObtenerProximasRespuestas(ListaPreguntas[Juego.ObtenerIdPreguntaMasChico()].Id);
           HttpContext.Session.SetString("juego", Juego);

            return View("Juego");
        }
    }
    [HttpPost]
    public IActionResult VerificarRespuesta(int idRespuesta)
    {   
        Juego Juego = Objeto.StringToObject<Juego>(HttpContext.Session.GetString("Jueg"));
        bool Correcta = Juego.VerificarRespuesta(idRespuesta);
        return View("Juego");
    } 
}
