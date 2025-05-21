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
                resultado += "_";
                }
                    
            }
            return resultado;
        }

        public static void ProbarLetra(char letra)
        {
            if (!letrasUsadas.Contains(letra) && !juegoTerminado)
            {
                letrasUsadas.Add(letra);
                if (!palabraSecreta.Contains(letra))
                {
                    intentos++;
                }
               
            }
        }


        public static void ProbarPalabra(string palabra)
        {
            if (!juegoTerminado)
            {
                if (palabra == palabraSecreta)
                {
                    foreach (char letra in palabraSecreta)
                        if (!letrasUsadas.Contains(letra)){
                            letrasUsadas.Add(letra);
                        }
                            
                }
             
                juegoTerminado = true;
            }
        }


        
    }
}


