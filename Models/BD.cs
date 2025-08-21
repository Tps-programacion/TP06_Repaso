namespace TP06_REPASO.Models;
using System;
using Microsoft.Data.SqlClient;
using Dapper;
public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase = BaseDatosTP06_REPASO; Trusted_Connection = true; TrustServerCertificate = true" ;
 
    static public int logIn(string username, string contraseña)
    {
        int idUsuario = -1;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT IDUsuario FROM Usuarios WHERE username = @username AND contraseña = @contraseña";
            idUsuario = connection.QueryFirstOrDefault <int> (query, new {username,contraseña});
        }
        return idUsuario;
    }
    
    
    public static void agendarTarea(Tarea tarea)   
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuarios (IDTarea,Titulo,Descripcion,Fecha,Finalizada,IDUsuario) VALUES (@tarea.IDTarea, @tarea.Titulo, @tarea.Descripcion, @tarea.Fecha, @tarea.Finalizada, @tarea.IDUsuario)";
            connection.Execute (query, new {tarea});
        }
    }

    public static void registro(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuarios (Nombre,Apellido,Username,Contraseña,Foto,FechaUltimoLog) VALUES (@usuario.Nombre, @usuario.Apellido, @usuario.Username, @usuario.Contraseña, @usuario.Foto, @usuario.FechaUltimoLog)";
            connection.Execute(query, new {usuario});
        }
    }

    public static void modificarTarea(string titulo, string descripcion, DateTime fecha, Tarea tareaAModificar)
    {
      
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tarea SET titulo = @titulo, descripcion = @descripcion, fecha = @fecha WHERE, IDTarea = @IDTarea";
            connection.Execute (query, new {titulo, descripcion, fecha, tareaAModificar.IDTarea});
        }
        
    }

    public static void eliminarTarea(int IDTarea)
    {
      string query = "DELETE * FROM Tarea WHERE IDTarea = @IDTarea";
      using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new {IDTarea});
        }
    }

    public static Tarea verTarea(int IDTarea)
    {
        Tarea tareaBuscada;
    using (SqlConnection connection = new SqlConnection(_connectionString))
        {
             string query = "SELECT * FROM Tarea WHERE IDTarea = @IDTarea";
             tareaBuscada = connection.QueryFirstOrDefault <Tarea> (query, new {IDTarea});
        }
    return tareaBuscada;
    }

    public static List<Tarea> verTareas(int IDUsuario)
    {
        List<Tarea> tareas = new List<Tarea>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tarea WHERE IDUsuario = @IDUsuario";
            tareas = connection.Query<Tarea>(query, new {IDUsuario}).ToList();
        }
        return tareas;
    }

    public static Usuario GetUsuario(int IDUsuario){
        Usuario usuario = null;
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Usuarios WHERE IDUsuario = @IDUsuario";
            usuario = connection.QueryFirstOrDefault <Usuario> (query, new {IDUsuario});
        }
        return usuario;
    }
    public static void FinalizarTarea(int IDTareaFin)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tarea SET Finalizada = 1 WHERE IDTarea = @IDTareaFin";
            connection.Execute (query, new {IDTareaFin});
        }
    }
   public static void modificarFecha(int IDTarea, DateTime fechaNueva)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "UPDATE Tarea SET fecha = @FechaNueva WHERE IDTarea = @IDTarea";
            connection.Execute (query, new { IDTarea, FechaNueva = fechaNueva });
        }
    }
}


