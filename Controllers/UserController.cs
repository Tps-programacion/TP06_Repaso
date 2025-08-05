using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP06_REPASO.Models;
using Newtonsoft.Json;
namespace TP06_REPASO.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    public IActionResult login()
    {
        return View();
    }

    public IActionResult logout(){
        return View();
    }
    public IActionResult loginGuardar()
    {
        return View();
    }
    
        public IActionResult registro()
    {
        return View();
    }
    
        public IActionResult registroGuardar()
    {
        return View();
    }

    
    

}
