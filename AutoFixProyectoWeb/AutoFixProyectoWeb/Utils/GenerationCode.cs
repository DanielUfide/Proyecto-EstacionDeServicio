using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoFixProyectoWeb.Utils
{
    public class GenerationCode
    {
        public static string GenerarCodigoDe8Digitos()
        {
            Random random = new Random();
            return random.Next(10000000, 99999999).ToString();
        }
    }
}