public class Categorias
{
  public int Id {get;private set;}
  public string Nombre{get;private set;}
 public string Foto{get;private set;}
public Categorias(  string pNombre,string pFoto)
{

    this.Nombre = pNombre;
    this.Foto = pFoto;   
}



}
