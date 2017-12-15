using EsceulasWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsceulasWeb.Controllers
{
    public class HomeController : Controller
    {
        ESCUELASEntities1 cnx;
       
        public HomeController()
        {
          cnx = new ESCUELASEntities1();

        }
        public ActionResult Formulario()
        {

            return View();
        }

        public ActionResult Listado()
        {

            cnx.Database.Connection.Open();

            List<PROFESOR> profesores = cnx.PROFESOR.ToList();
            cnx.Database.Connection.Close();
            return View(  profesores );
        }

        public ActionResult Guardar( string rut, string nombre, string titulo, string grado) {

            return View("Listado");
        }


        public ActionResult Ficha(string rut, string nombre, string titulo, string grado)
        {
            PROFESOR profe = new PROFESOR()
            {
                Rut = rut,
                Nombre = nombre,
                Titulo = titulo,
                Grado = grado
            };

            cnx.PROFESOR.Add(profe);
            cnx.SaveChanges();
            return View(profe);
        }

        public ActionResult Ver(string rut)
        {
            

            return View("Ficha", null);
        }
    }
    }