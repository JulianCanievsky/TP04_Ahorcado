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
     
            ViewBag.Palabra = Juego.MostrarPalabra();
    ViewBag.Intentos = Juego.intentos;
    ViewBag.LetrasUsadas = Juego.letrasUsadas;
    ViewBag.Terminado = Juego.juegoTerminado;
    ViewBag.Secreta = Juego.palabraSecreta;
   return View("Jugar");
    }
    
       
        [HttpPost]
        public IActionResult ProbarLetra(char letra)
        {
            if(letra != null){
            char a = letra; 
                Juego.ProbarLetras(a);
            
            }
            if(Juego.palabraSecreta == Juego.MostrarPalabra()){
                string resultado = "¡GANASTE!";
                ViewBag.resultado = resultado;
                ViewBag.Secreta = Juego.palabraSecreta;
                return View("resultado");
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
        
            string resultado = "Perdiste";
            if (palabra != null){
            
            if(Juego.ProbarPalabra(palabra)){
                resultado = "Ganaste";
            }
            }
            

            ViewBag.resultado= resultado;
            ViewBag.Secreta = Juego.palabraSecreta;

            return View("resultado");
        }
    }

