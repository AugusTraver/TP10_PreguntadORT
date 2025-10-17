using System.Diagnostics;
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
            Juego juego = new Juego();
            juego.CargarPartida(username, categoria);

            string juegoStr = Objeto.ObjectToString(juego);
            HttpContext.Session.SetString("juego", juegoStr);

            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            string juegoStr = HttpContext.Session.GetString("juego");
            if (string.IsNullOrEmpty(juegoStr))
            {
                return RedirectToAction("Index");
            }

            Juego juego = Objeto.StringToObject<Juego>(juegoStr);

            if (juego.ListaPreguntas.Count == 0)
            {
                return View("Fin");
            }
            else
            {
                // Asegurarse de que haya una pregunta actual
                if (juego.PreguntaActual == null && juego.ListaPreguntas.Count > 0)
                {
                    juego.ObtenerProximaPregunta();
                }

                ViewBag.PreguntaActual = juego.PreguntaActual;

                int idPregunta = juego.ObtenerIdPreguntaMasChico();
                Preguntas preguntaActual = juego.ListaPreguntas.FirstOrDefault(p => p.Id == idPregunta);

                if (preguntaActual != null)
                {
                    List<Respuestas> listaRespuestas = juego.ObtenerProximasRespuestas(preguntaActual.Id);
                    ViewBag.ListaRespuestas = listaRespuestas;
                }
                else
                {
                    ViewBag.ListaRespuestas = new List<Respuestas>();
                }

                ViewBag.Username = juego.username;
                ViewBag.PuntajeActual = juego.PuntajeActual;
                //FALTA FOTO

                HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));

                return View("Juego");
            }
        }

        public IActionResult VerificarRespuesta(int idRespuesta)
        {
            string juegoStr = HttpContext.Session.GetString("juego");
            if (string.IsNullOrEmpty(juegoStr))
            {
                return RedirectToAction("Index");
            }

            Juego juego = Objeto.StringToObject<Juego>(juegoStr);

            ViewBag.Correcta = juego.VerificarRespuesta(idRespuesta);
            ViewBag.PreguntaActual = juego.PreguntaActual;

            int idPregunta = juego.ObtenerIdPreguntaMasChico();
            Preguntas preguntaActual = juego.ListaPreguntas.FirstOrDefault(p => p.Id == idPregunta);

            if (preguntaActual != null)
            {
                List<Respuestas> listaRespuestas = juego.ObtenerProximasRespuestas(preguntaActual.Id);
                ViewBag.ListaRespuestas = listaRespuestas;
            }
            else
            {
                ViewBag.ListaRespuestas = new List<Respuestas>();
            }

            HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego));

            return View("Juego");
        }
    }
}
