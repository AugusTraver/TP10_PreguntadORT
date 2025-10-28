using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TP10_AhorcadORT.Models;

namespace TP10_AhorcadORT.Controllers
{
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
            return View("ConfiguracionJuego");
        }

        public IActionResult Comenzar(string username, int categoria)
        {
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("ConfigurarJuego");

            Juego juego = new Juego();
            juego.CargarPartida(username, categoria);

            // Guardamos la partida en sesión
            string juegoStr = Objeto.ObjectToString(juego);
            HttpContext.Session.SetString("juego", juegoStr);

            // Redirigimos a la vista del juego
            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            string juegoStr = HttpContext.Session.GetString("juego");
            if (string.IsNullOrEmpty(juegoStr))
                return RedirectToAction("Index");

            Juego juego = Objeto.StringToObject<Juego>(juegoStr);

                Console.WriteLine("JuegoTerminado" + juego.JuegoTerminado());
            if (juego.JuegoTerminado())
                return View("Fin");

            // Actualizar ViewBags
            ViewBag.PreguntaActual = juego.PreguntaActual;
            ViewBag.ListaRespuestas = juego.ObtenerProximasRespuestas();
            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;

            // Guardar sesión actualizada
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));

            return View("Juego");
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idRespuesta)
        {
            string juegoStr = HttpContext.Session.GetString("juego");
            if (string.IsNullOrEmpty(juegoStr))
                return RedirectToAction("Index");

            Juego juego = Objeto.StringToObject<Juego>(juegoStr);

            bool esCorrecta = juego.VerificarRespuesta(idRespuesta);

            // Si ya terminó el juego después de responder
            if (juego.JuegoTerminado())
            {
                HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));
                return View("Fin");
            }

            // Actualizar ViewBags con nueva pregunta
            ViewBag.Correcta = esCorrecta;
            ViewBag.PreguntaActual = juego.PreguntaActual;
            ViewBag.ListaRespuestas = juego.ObtenerProximasRespuestas();
            ViewBag.Username = juego.Username;
            ViewBag.PuntajeActual = juego.PuntajeActual;

            // Actualizamos la sesión
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));

            return View("Juego");
        }
    }
}
