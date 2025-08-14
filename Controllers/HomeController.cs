using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_REPASO.Models;
using Newtonsoft.Json;
namespace TP06_REPASO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

        public IActionResult verTareas()
    {
        int id;
        id = int.Parse(HttpContext.Session.GetString("idUsuario"));
        List<Tarea> tareas = new List<Tarea>();
        tareas = BD.verTareas(id);
        ViewBag.tareas = tareas;
        return View("VerTareas");
        
    
    }

        public IActionResult nuevaTarea()
    {
        return View("NuevaTarea");
    }

        public IActionResult nuevaTrareaGuardar(string titulo, string descripcion, DateTime fecha)
    {
        int id;
        id = int.Parse(HttpContext.Session.GetString("idUsuario"));
        Tarea tarea = new Tarea(titulo, descripcion, fecha, id);
        BD.agendarTarea(tarea);
        ViewBag.mensaje("Tarea agregada correctamente");
        return View("mensajeTareaAgregada");
    }

    public IActionResult modificarTarea(int idTarea){
        
        Tarea tareaAModificar = BD.verTarea(idTarea);
        ViewBag.tareaAModificar = tareaAModificar;
        return View("ModificarTarea");
    }

    public IActionResult modificarTareaGuardar(string titulo, string descripcion, DateTime fecha, int idTarea)
    {
        //CUANDO SE RETURNEEN LAS TAREAS POR CADA TAREA QUE HAYA UN LINK QUE PERMITA EDITAR Y ELMINAR ESA MISMA TAREA
        // MISMA LOGICA QUE EN NUEVA TAREA
        Tarea tareaAModificar = BD.verTarea(idTarea); 
        BD.modificarTarea(titulo, descripcion, fecha, tareaAModificar);
        ViewBag.tareaModificada = BD.verTarea(idTarea); 
        ViewBag.mensaje("Tarea modificada correctamente");
        return View("Index");
    }

    public IActionResult eliminarTarea(int idTarea)
    {
        ViewBag.tareaAEliminar = BD.verTarea(idTarea);
        return View("EliminarTarea");
    }
    public IActionResult eliminarTareaGuardar(bool confirmacion, int idTarea)
    {
        if (confirmacion == true)
        {
            Tarea tareaAEliminar = BD.verTarea(idTarea);
            BD.eliminarTarea(idTarea);
            return View("ConfirmacionEliminarTarea");
        }
        else
        {
            return View("VerTareas");
        }
        
    }  
}
