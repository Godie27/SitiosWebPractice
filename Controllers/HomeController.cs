using Semana5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semana5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Models.SqlMethods obj = new Models.SqlMethods();
            List<Tarjeta> lista = obj.CargarImagenes();

            return View("Main", lista);
        }

        public ActionResult Main()
        {
            Models.SqlMethods obj = new Models.SqlMethods();
            List<Tarjeta> lista = obj.CargarImagenes();

            return View(lista);
        }

        [HttpPost]
        public ActionResult SubirImagen()
        {
            Models.SqlMethods i = new Models.SqlMethods();

            string titulo = Request.Form["titulo"];
            string tipo = HttpContext.Request.Form["radio"];

            // Obtiene la imagen como un arreglo de bytes
            HttpPostedFileBase imagen = Request.Files["imagen"];
            byte[] imagenBytes = new byte[imagen.ContentLength];
            imagen.InputStream.Read(imagenBytes, 0, imagen.ContentLength);


            bool valido = i.SubirImagen(titulo, tipo, imagenBytes);

            if (valido)
            {
                return RedirectToAction("Main");

            }
            else
            {
                ViewBag.ErrorMessage = "Hubo un error al Subir la imagen.";
                return View(); // Devuelve la vist

            }
        }//end Subir Imagen 

        public ActionResult CargarImagenes()
        {
            Models.SqlMethods obj = new Models.SqlMethods();
            List<Tarjeta> lista =  obj.CargarImagenes();

            return View(lista); 
        }





    }
}