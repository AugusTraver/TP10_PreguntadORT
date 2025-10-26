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
        // INICIALIZACIÓN DEL JUEGO
        // -------------------------
        public void InicializarJuego()
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
        // CARGA DE PARTIDA
        // -------------------------
        public void CargarPartida(string username, int categoria)
        {
            InicializarJuego();
            Username = username;

            ListaPreguntas = BD.ObtenerPreguntas(categoria);
            Console.WriteLine($"Preguntas cargadas: {ListaPreguntas.Count}");

            if (ListaPreguntas.Count > 0)
            {
                ObtenerProximaPregunta();
            }
        }

        // -------------------------
        // PREGUNTAS Y RESPUESTAS
        // -------------------------
        public Preguntas ObtenerProximaPregunta()
        {
            if (ContadorNroPreguntaActual >= ListaPreguntas.Count)
            {
                PreguntaActual = null;
                return null;
            }

            PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
            ContadorNroPreguntaActual++;

            RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            Console.WriteLine($"Pregunta actual: {PreguntaActual.Enunciado} (ID: {PreguntaActual.Id})");

            return PreguntaActual;
        }

        public List<Respuestas> ObtenerProximasRespuestas()
        {
            if (PreguntaActual == null)
                return new List<Respuestas>();

            RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);
            return RespuestasActual;
        }

        // -------------------------
        // VERIFICACIÓN DE RESPUESTA
        // -------------------------
        public bool VerificarRespuesta(int idRespuesta)
        {
            if (PreguntaActual == null)
                return false;

            // Obtener respuestas de la pregunta actual
            RespuestasActual = BD.ObtenerRespuestas(PreguntaActual.Id);

            var respuestaSeleccionada = RespuestasActual.FirstOrDefault(r => r.Id == idRespuesta);
            var respuestaCorrecta = RespuestasActual.FirstOrDefault(r => r.Correcta);

            bool esCorrecta = (respuestaSeleccionada != null && respuestaSeleccionada.Correcta);

            if (esCorrecta)
            {
                CantidadPreguntasCorrectas++;
                PuntajeActual += 10;
            }

            // Pasar a la siguiente pregunta
            ObtenerProximaPregunta();

            return esCorrecta;
        }

        // -------------------------
        // FIN DE JUEGO
        // -------------------------
        public bool JuegoTerminado()
        {
            return ContadorNroPreguntaActual >= ListaPreguntas.Count || PreguntaActual == null;
        }
    }
}
