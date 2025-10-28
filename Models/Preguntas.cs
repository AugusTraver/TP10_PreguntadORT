namespace TP10_AhorcadORT.Models;
using Newtonsoft.Json;

public class Preguntas
{
    [JsonProperty]
    public int Id { get; private set; }
    [JsonProperty]
    public int IdCategorias { get; private set; }
    [JsonProperty]
    public string Enunciado { get; private set; }
    [JsonProperty]
    public string Foto { get; private set; }
    public Preguntas() { }
    public Preguntas(int pIdCategorias, string pEnunciado, string pFoto)
    {

        IdCategorias = IdCategorias;
        Enunciado = pEnunciado;
        Foto = pFoto;
    }
}