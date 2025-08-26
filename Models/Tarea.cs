namespace TP06_REPASO;
using Newtonsoft.Json;

public class Tarea 
{


[JsonProperty("IDTarea")]
    public int IDTarea { get; private set; }

    [JsonProperty("Titulo")]
    public string Titulo { get; set; }

    [JsonProperty("Descripcion")]
    public string Descripcion { get; set; }

    [JsonProperty("Fecha")]
    public DateTime Fecha { get; set; }

    [JsonProperty("Finalizada")]
    public bool Finalizada { get; set; }

    [JsonProperty("IDUsuario")]
    public int IDUsuario { get; private set; }

    public Tarea() 
    { 
        
    }
    public Tarea(string titulo, string descripcion, DateTime fecha, int iDUsuario){
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Fecha = fecha;
        this.Finalizada = false;
        this.IDUsuario = iDUsuario;
    }
}
