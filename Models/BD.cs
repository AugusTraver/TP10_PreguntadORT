
using Microsoft.Data.SqlClient;
using Dapper;
namespace TP10_AhorcadORT.Models;
public static class BD
{
    private static string _connectionString = @"Server = localHost; DataBase = PreguntadOrt; Integrated Security = True;TrustServerCertificate=True;";

    public static List<Categorias> ObtenerCategorias()
    {
        List<Categorias> ListaCategorias = new List<Categorias>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Categorias";
            ListaCategorias = connection.Query<Categorias>(query).ToList();
        }
        return ListaCategorias;
    }

    public static List<Preguntas> ObtenerPreguntas(int categoriaa)
    {
        string query;
        Console.WriteLine("CATEGORIA¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡¡ " + categoriaa);
        List<Preguntas> ListaPreguntas = new List<Preguntas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            if (categoriaa == -1)
            {
                query = "SELECT * FROM Preguntas";
            }
            else
            {
                query = "SELECT * FROM Preguntas WHERE IdCategoria = @Categoria ";
            }
            Console.WriteLine("QUERY!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! " + query);
            ListaPreguntas = connection.Query<Preguntas>(query, new { Categoria = categoriaa }).ToList();
        }
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!" + ListaPreguntas[1]);
        return ListaPreguntas;
    }
    public static List<Respuestas> ObtenerRespuestas(int idPregunta)
    {
        List<Respuestas> respuestas = new List<Respuestas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Respuestas WHERE IdPregunta = @idP ";
            respuestas = connection.Query<Respuestas>(query, new { idP = idPregunta }).ToList();
        }
        return respuestas;
    }
}