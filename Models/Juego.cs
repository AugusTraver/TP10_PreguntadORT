
public class Juego
{

    public string username { get; private set; }
    public int PuntajeActual { get; private set; }
    public int CantidadPreguntasCorrectas { get; private set; }
    public int ContadorNroPreguntaActual { get; private set; }
    public Preguntas PreguntaActual { get; private set; }
    public List<Preguntas> ListaPreguntas { get; private set; }
    public List<Respuestas> ListaRespuestas { get; private set; }
    public List<Respuestas> RespuestasActual { get; private set; }

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
        
        RespuestasActual = BD.ObtenerRespuestas(idPregunta);
        return RespuestasActual;
    }
    private bool VerificarRespuesta(int idRespuesta)
    {
        bool correctaa = false;
        RespuestasActual = BD.ObtenerRespuestas(ObtenerIdPreguntaMasChico());
        Respuestas respuestaCorrecta = null;
        ListaRespuestas.Remove(ObtenerIdPreguntaMasChico());
        for (int i = 0; i < RespuestasActual.Count; i++)
        {
            if (RespuestasActual[i].Correcta)
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
        ContadorNroPreguntaActual += 1;
        PreguntaActual = ListaPreguntas[ContadorNroPreguntaActual];
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