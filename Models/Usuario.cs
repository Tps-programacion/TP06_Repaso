namespace TP06_REPASO;
using Newtonsoft.Json;

public class Usuario 
{
    
     [JsonProperty("IDUsuario")]
    public int IDUsuario { get; private set; }

    [JsonProperty("Nombre")]
    public string Nombre { get; private set; }

    [JsonProperty("Apellido")]
    public string Apellido { get; private set; }

    [JsonProperty("Username")]
    public string Username { get; private set; }

    [JsonProperty("Contraseña")]
    public string Contraseña { get; private set; }

    [JsonProperty("Foto")]
    public string Foto { get; private set; }

    [JsonProperty("FechaUltimoLog")]
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