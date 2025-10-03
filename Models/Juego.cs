
public class Juego
{

    public string username { get; private set; }
    public int PuntajeActual { get; private set; }
    public int CantidadPreguntasCorrectas { get; private set; }
    public int ContadorNroPreguntaActual { get; private set; }
    public Preguntas PreguntaActual { get; private set; }
    public List<Preguntas> ListaPreguntas { get; private set; }
    public List<Respuestas> ListaRespuestas { get; private set; }


    private void InicializarJuego()
    {
        username = null;
        PuntajeActual = 0;
        CantidadPreguntasCorrectas = 0;
        ContadorNroPreguntaActual = 0;
        PreguntaActual = null;
        ListaPreguntas = null;
        ListaRespuestas = null;
    }

    private void CargarPartida(string Username, int categoria)
    {
        InicializarJuego();
        username = Username;
        ListaPreguntas = BD.ObtenerPreguntas(categoria);

    }
    private List<Categorias> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }
    private string ObtenerProximaPregunta()
    {

        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
        ContadorNroPreguntaActual++;

        return PreguntaActual;
    }
    private List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        return BD.ObtenerRespuestas(idPregunta);
    }
    private bool VerificarRespuesta(int idRespuesta)
    {
        bool correctaa = false;
        List<Respuestas> Respuestas = BD.ObtenerRespuestas(ObtenerIdPreguntaMasChico());
        Respuestas respuestaCorrecta = null;
        ListaRespuestas.Remove(ObtenerIdPreguntaMasChico());
        for (int i = 0; i < Respuestas.Count; i++)
        {
            if (Respuestas[i].Correcta)
            {
                respuestaCorrecta = listaRespuestas[i];
                break;
            }
        }
        if (idRespuesta = respuestaCorrecta.Id)
        {
            correctaa = true;
            CantidadPreguntasCorrectas += 1;
            PuntajeActual += 10;
          
        }
        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
        ContadorNroPreguntaActual += 1;
        return correctaa;
    }
    public int ObtenerIdPreguntaMasChico()
    {
        int idMinimo = ListaPreguntas[0].Id;

        for (int i = 1; i < ListaPreguntas.Count; i++)
        {
            if (ListaPreguntas[i].Id < idMinimo)
            {
                idMinimo = ListaPreguntas[i].Id;
            }
        }

        return idMinimo;
    }
}