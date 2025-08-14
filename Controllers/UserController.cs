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

public IActionResult login(string username, string contraseña)
    {
        return View("login");
    }

    public IActionResult logout()
    {

        HttpContext.Session.Remove("idUsuario");
        ViewBag.mensaje = "Usted salió correctamente de la sesión.";
        return View("Index");
    }
    public IActionResult loginGuardar(string username, string contraseña)
    {
        if (HttpContext.Session.GetString("idUsuario") != null)
        {
            ViewBag.mensaje = "Ya hay un usuario logueado. Para ingresar denuevo primero salga de sesion";
            return View("Login");

        }
        else
        {
            int id = -1;
            id = BD.logIn(username, contraseña);

            if (id != -1)
            {
                Usuario usuarioLogueado;
                usuarioLogueado = BD.GetUsuario(id);
                ViewBag.usuario = usuarioLogueado;
                ViewBag.mensaje = "Bienvenido ";
                HttpContext.Session.SetString("idUsuario", id.ToString());
                return View("Bienvenida");
            }
            else
            {
                ViewBag.mensaje = "Uno de los campos o ambos fueron ingresados incorrectamente.";
                return View("Login");

            }

        }
    }
    
        public IActionResult registro()
    {
        return View("registro");
    }
    
        public IActionResult registroGuardar(string nombre, string apellido, string username, string contraseña, string foto)
    {
        DateTime ultimoLogin; 

        int id = BD.logIn(username, contraseña); // Hacer en bd un getusuario y si no existe que devuelva NULL 

        if(id == -1){
            ultimoLogin = DateTime.Today;
            Usuario usuario = new Usuario(nombre, apellido, username, contraseña, foto, ultimoLogin); 
            BD.registro(usuario);
            ViewBag.mensaje("Usuario registrado correctamente");
            return View("registroCorrecto");    
        }
        
        else{
            ViewBag.mensaje("El usuario con el username "+ username + " ya existe.");
            return View("registro");
        }


        
    }

    
    

}
