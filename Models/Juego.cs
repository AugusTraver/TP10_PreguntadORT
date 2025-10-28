using System;
using System.Collections.Generic;
using System.Linq;

namespace TP10_AhorcadORT.Models
{
    public class Juego
    {
        public string Username { get; private set; }
        public int PuntajeActual { get; private set; }
        public int CantidadPreguntasCorrectas { get; private set; }
        public int ContadorNroPreguntaActual { get; private set; }
        public Preguntas PreguntaActual { get; private set; }
        public List<Preguntas> ListaPreguntas { get; private set; } = new();
        public List<Respuestas> RespuestasActual { get; private set; } = new();

        // -------------------------
        // INICIALIZAR JUEGO
        // -------------------------
        private void InicializarJuego()
        {
            Username = "";
            PuntajeActual = 0;
            CantidadPreguntasCorrectas = 0;
            ContadorNroPreguntaActual = 0;
            PreguntaActual = null;
            ListaPreguntas = new List<Preguntas>();
            RespuestasActual = new List<Respuestas>();
        }

        // -------------------------
        // CARGAR PARTIDA
        // -------------------------
        public void CargarPartida(string username, int categoria)
        {
            InicializarJuego();
            Username = username;

            ListaPreguntas = BD.ObtenerPreguntas(categoria);

            if (ListaPreguntas != null && ListaPreguntas.Count > 0)
            {
                ContadorNroPreguntaActual = 0;
                PreguntaActual = ListaPreguntas[0];
                Console.WriteLine("PREGUNTA ACTUAAL" + PreguntaActual.Enunciado);
                RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            }
        }

        // -------------------------
        // OBTENER PRÓXIMA PREGUNTA
        // -------------------------
        public Preguntas ObtenerProximaPregunta()
        {
            // Si ya no hay más preguntas, se termina
            if (ListaPreguntas == null || ContadorNroPreguntaActual >= ListaPreguntas.Count)
            {
                PreguntaActual = null;
                return null;
            }

            PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
            RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            return PreguntaActual;
        }

        // -------------------------
        // OBTENER RESPUESTAS ACTUALES
        // -------------------------
        public List<Respuestas> ObtenerProximasRespuestas()
        {
            if (PreguntaActual == null)
                return new List<Respuestas>();

            RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            return RespuestasActual;
        }

        // -------------------------
        // VERIFICAR RESPUESTA
        // -------------------------
        public bool VerificarRespuesta(int idRespuesta)
        {
            if (PreguntaActual == null)
                return false;

            var respuestas = BD.ObtenerRespuestas(PreguntaActual.Id);
            var respuestaSeleccionada = respuestas.FirstOrDefault(r => r.Id == idRespuesta);
            var esCorrecta = respuestaSeleccionada != null && respuestaSeleccionada.Correcta;

            if (esCorrecta)
            {
                CantidadPreguntasCorrectas++;
                PuntajeActual += 10;
            }

            // Avanzar a la siguiente pregunta
            ContadorNroPreguntaActual++;

            // Si quedan preguntas, actualizar la actual
            if (ContadorNroPreguntaActual < ListaPreguntas.Count)
            {
                PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
                RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            }
            else
            {
                PreguntaActual = null;
                RespuestasActual = new List<Respuestas>();
            }

            return esCorrecta;
        }


        public bool JuegoTerminado()
        {
                            Console.WriteLine("PRegunta acutal?" + PreguntaActual);

            return PreguntaActual == null || ContadorNroPreguntaActual >= ListaPreguntas.Count;
        }
    }
}
