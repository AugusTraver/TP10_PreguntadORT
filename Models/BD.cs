
using Microsoft.Data.SqlClient;
using Dapper;
namespace TP10_AhorcadORT.Models;
public class BD
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
        List<Preguntas> ListaPreguntas = new List<Preguntas>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Preguntas WHERE IdCategorias = @Categoria ";
            ListaPreguntas = connection.Query<Preguntas>(query, new { Categoria = categoriaa }).ToList();
        }
        return ListaPreguntas;
    }
    public static Respuestas ObtenerRespuestas(int idPregunta)
    {
        Respuestas respuesta;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Respuestas WHERE Id = @idP ";
            respuesta = connection.QueryFirstOrDefault<Respuestas>(query, new { idP = idPregunta });
        }
        return respuesta;
    }   
}