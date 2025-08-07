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
            string query = "SELECT IDUsuario FROM Usuario WHERE username = @username AND contraseña = @contraseña";
            idUsuario = connection.QueryFirstOrDefault <int> (query, new {username,contraseña});
        }
        return idUsuario;
    }
    
    
    public static void agendarTarea(Tarea tarea)   
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuario(IDTarea,Titulo,Descripcion,Fecha,Finalizada,IDUsuario) VALUES (@tarea.IDTarea, @tarea.Titulo, @tarea.Descripcion, @tarea.Fecha, @tarea.Finalizada, @tarea.IDUsuario)";
            connection.QueryFirstOrDefault <int> (query, new {tarea});
        }
    }

    public static void registro(Usuario usuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "INSERT INTO Usuario(Nombre,Apellido,Username,Contraseña,Foto,FechaUltimoLog) VALUES (@usuario.Nombre, @usuario.Apellido, @usuario.Username, @usuario.Contraseña, @usuario.Foto, @usuario.FechaUltimoLog)";
            connection.QueryFirstOrDefault <int> (query, new {usuario});
        }
    }

    public static void modificarTarea()
    {

        
    }

    public static void eliminarTarea(int IDTarea)
    {
      using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "DELETE * FROM Tarea WHERE IDTarea = @IDTarea";
            connection.QueryFirstOrDefault <int> (query, new {IDTarea});
        }
    }

    public static void verTarea(int IDTarea)
    {
    using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Tarea WHERE IDTarea = @IDTarea";
            connection.QueryFirstOrDefault <int> (query, new {IDTarea});
        }
    }

    public static void verTareas(int idUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT Tarea. FROM Tarea WHERE IDTarea = @IDTarea";
            connection.QueryFirstOrDefault <int> (query, new {idUsuario});
        }
    }

    public static void aa(){
    
    }

    public static void regaistro(){
    
    }

}


