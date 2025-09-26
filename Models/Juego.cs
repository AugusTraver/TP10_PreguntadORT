
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



    private void CargarPartida(string username, int categoria)
    {
        InicializarJuego();
        BD.ObtenerPreguntas(categoria);

    }
    private List<Categorias> ObtenerCategorias()
    {

    }
}