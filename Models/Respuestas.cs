namespace TP10_AhorcadORT.Models;
using Newtonsoft.Json;

public class Respuestas
{
    [JsonProperty]
    public int Id { get; private set; }
    [JsonProperty]
    public int IdPregunta { get; private set; }
    [JsonProperty]
    public int Opcion { get; private set; }
    [JsonProperty]
    public string Contenido { get; private set; }
    [JsonProperty]
    public bool Correcta { get; private set; }
    [JsonProperty]
    public string Foto { get; private set; }

    public Respuestas()
    { }
    public Respuestas(int PIdPregunta, int POpcion, string PContenido, bool PCorrecta, string PFoto)
    {


        IdPregunta = PIdPregunta;
        Opcion = POpcion;
        Contenido = PContenido;
        Correcta = PCorrecta;
        Foto = PFoto;

    }
}