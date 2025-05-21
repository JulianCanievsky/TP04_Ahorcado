using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Canievsky.Models;

namespace TP04_Canievsky.Controllers;

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
    public IActionResult NuevaPartida(){
        Juego.IniciarJuego();
        return View("Jugar");
            ViewBag.Palabra = Juego.MostrarPalabra();
    ViewBag.Intentos = Juego.intentos;
    ViewBag.LetrasUsadas = Juego.letrasUsadas;
    ViewBag.Terminado = Juego.juegoTerminado;
    ViewBag.Secreta = Juego.palabraSecreta;

    }
    
       
        [HttpPost]
        public IActionResult ProbarLetra(char letra)
        {
            if(letra != null){
            char a = letra; 
                Juego.ProbarLetra(a);
            
            }
             
            ViewBag.Palabra = Juego.MostrarPalabra();
            ViewBag.Intentos = Juego.intentos;
            ViewBag.LetrasUsadas = Juego.letrasUsadas;
            ViewBag.Terminado = Juego.juegoTerminado;
            ViewBag.Secreta = Juego.palabraSecreta;

            return View("Jugar");
        }

        
        [HttpPost]
        public IActionResult ProbarPalabra(string palabra)
        {
        
            if (palabra != null){
            Juego.ProbarPalabra(palabra);
            
            }

            ViewBag.Palabra = Juego.MostrarPalabra();
            ViewBag.Intentos = Juego.intentos;
            ViewBag.LetrasUsadas = Juego.letrasUsadas;
            ViewBag.Terminado = Juego.juegoTerminado;
            ViewBag.Secreta = Juego.palabraSecreta;

            return View("Jugar");
        }
    }

