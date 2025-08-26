namespace TP06_REPASO;
using Newtonsoft.Json;

public  class Usuario 
{
    
    public int IDUsuario { get; private set; }

 
    public string Nombre { get; private set; }

    public string Apellido { get; private set; }

    public string Username { get; private set; }

    public string Contraseña { get; private set; }

    public string Foto { get; private set; }

    public DateTime FechaUltimoLog { get; private set;}
    public Usuario(){

    }
    public Usuario (string Nombre, string Apellido, string Username, string Contraseña, string Foto, DateTime FechaUltimoLog)
    {
    this.Nombre = Nombre;
    this.Apellido = Apellido;
    this.Username = Username;
    this.Contraseña = Contraseña;
    this.Foto = Foto;
    this.FechaUltimoLog = FechaUltimoLog;
    }
}