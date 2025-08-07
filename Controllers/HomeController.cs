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
        return View("tareas");
        
    
    }

        public IActionResult nuevaTarea()
    {
        return View("nuevaTarea");
    }

        public IActionResult nuevaTrareaGuardar(string titulo, string descripcion, DateTime fecha)
    {
        
        Tarea tarea = new Tarea( titulo, descripcion, fecha);
        BD.agendarTarea(tarea);
        ViewBag.mensaje("Tarea agregada correctamente");
        return View("mensajeTareaAgregada");
    }

    public IActionResult modificarTarea(int idTarea){
        return View("modificarTarea");
        Tarea tareaAModificar = BD.verTarea(idTarea);
        ViewBag.tareaAModificar = tareaAModificar;
    }

    public IActionResult modificarTareaGuardar()
    {
        //CUANDO SE RETURNEEN LAS TAREAS POR CADA TAREA QUE HAYA UN LINK QUE PERMITA EDITAR Y ELMINAR ESA MISMA TAREA
        // MISMA LOGICA QUE EN NUEVA TAREA
        return View();
    }

    public IActionResult eliminarTarea()
    {
        return View();
    }
    public IActionResult eliminarTareaGuardar()
    {
        return View();
    }  
}
