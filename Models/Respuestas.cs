public class Respuestas
{
    public int Id {get; private set;}
    public int IdPregunta {get; private set;}
    public int Opcion{get; private set;}
    public string Contenido{get; private set;}
    public bool Correcta{get; private set;}
    public string Foto {get; private set;}

public Respuestas (int PIdPregunta, int POpcion, string PContenido, bool PCorrecta, string PFoto){

    
    IdPregunta = PIdPregunta;
    Opcion = POpcion;
    Contenido = PContenido;
    Correcta = PCorrecta;
    Foto = PFoto;

}
}