namespace TP10_AhorcadORT.Models;
using Newtonsoft.Json;

public class Categorias
{
  [JsonProperty]
  public int Id {get;private set;}
  [JsonProperty]
  public string Nombre{get;private set;}
  [JsonProperty]
 public string Foto{get;private set;}
 public Categorias() { }
public Categorias(  string pNombre,string pFoto)
{

    this.Nombre = pNombre;
    this.Foto = pFoto;   
}



}
