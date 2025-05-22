namespace TP04_Canievsky.Models
{
    public static class Juego
    {
        public static string palabraSecreta = ""; 
      public static List<string> palabras = new List<string> { "computadora", "programacion", "ahorcado", "teclado" };

        public static List<char> letrasUsadas = new List<char>();
        public static int intentos = 0;
        public static bool juegoTerminado = false;


        public static void IniciarJuego()
        {
             Random rd = new Random();
            int rand_num = rd.Next(0, 4);
            palabraSecreta = palabras[rand_num];
            letrasUsadas.Clear();
            intentos = 0;
            juegoTerminado = false;
        }


        public static string MostrarPalabra()
        {
            string resultado = "";
            foreach (char letra in palabraSecreta)
            {
                if (letrasUsadas.Contains(letra))
                { 
                     resultado += letra;
                }   
                else{
                resultado += "_ ";
                }
                    
            }
            return resultado;
        }

        public static void ProbarLetras(char letra)
        {
            if (!letrasUsadas.Contains(letra) && !juegoTerminado)
            {
                letrasUsadas.Add(letra);
              
               intentos++;
            }
            
        }


        public static bool ProbarPalabra(string palabra)
        {
            bool gano = false;
            if (!juegoTerminado)
            {
                if (palabra == palabraSecreta)
                {
                    foreach (char letra in palabraSecreta)
                        if (!letrasUsadas.Contains(letra)){
                            letrasUsadas.Add(letra);
                        }
                        gano = true;    
                }
             
                juegoTerminado = true;
            }
            return gano;
        }


        
    }
}


