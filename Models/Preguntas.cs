public class Preguntas
{
    public int Id {get;private set;}
    public int IdCategorias{get;private set;}
    public string Enunciado {get;private set;}
    public string Foto {get;private set;}
public Preguntas( int pIdCategorias, string pEnunciado, string pFoto)
  {
    
    IdCategorias = IdCategorias;
    Enunciado = pEnunciado;
    Foto = pFoto;
  }
}