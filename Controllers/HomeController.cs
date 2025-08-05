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
        return View();
    }

        public IActionResult nuevaTarea()
    {
        return View();
    }

        public IActionResult nuevaTrareaGuardar(string titulo, string descripcion, DateTime fecha)
    {
        return View();
    }

    public IActionResult moverTarea(){
        return View();
    }

    public IActionResult moverTareaGuardar()
    {
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
