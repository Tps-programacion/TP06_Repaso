namespace TP06_REPASO;
using Newtonsoft.Json;

public class Tarea 
{


[JsonProperty("IDTarea")]
    public int IDTarea { get; private set; }

    [JsonProperty("Titulo")]
    public string Titulo { get; private set; }

    [JsonProperty("Descripcion")]
    public string Descripcion { get; private set; }

    [JsonProperty("Fecha")]
    public DateTime Fecha { get; private set; }

    [JsonProperty("Finalizada")]
    public bool Finalizada { get; private set; }

    [JsonProperty("IDUsuario")]
    public int IDUsuario { get; private set; }

    public Tarea() { 
        
    }
    public Tarea(string titulo, string descripcion, DateTime fecha, int iDUsuario){
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Fecha = fecha;
        this.Finalizada = false;
        this.IDUsuario = iDUsuario;
    }
}
