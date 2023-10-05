using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Semana5.Models
{
    public class Tarjeta
    {
        public string Titulo { get; set; }

        public string Tipo { get; set; }

        public string Imagen { get; set; }

        public Tarjeta(string titulo, string tipo, string imagen)
        {
            Titulo = titulo;
            Tipo = tipo;
            Imagen = imagen;
        }


    }
}