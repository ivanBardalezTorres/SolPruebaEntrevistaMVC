using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaEntrevistaMVC.Models;
using System.Net.Http;
using System.Threading.Tasks;


namespace PruebaEntrevistaMVC.Controllers
{
    public class HomeController : Controller
    {
        //Lista los paises que está consumiendo del API RESTfull
        public async Task<ActionResult> ListaPais()
        {
            var httpCliente = new HttpClient();
            //Permite hacer una consulta GET al URL que tenemos del servicio
            var Json = await httpCliente.GetStringAsync("https://api.samishop.pe/v1/store/971/ubigeo/paises");
            //se instalo el paquete nuget NewtonSoft para utilizar esta conversion de Json a una lista del tipo cPais
            List<cPais> Paises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<cPais>>(Json);
            ViewBag.lstPais = Paises;
            return View();
        }
        public async Task<ActionResult> Index()
        {
            var httpCliente = new HttpClient();
            //Permite hacer una consulta GET al URL que tenemos del servicio

            var Json = await httpCliente.GetStringAsync("http://localhost:50563/api/Pais");
            //se instalo el paquete nuget NewtonSoft para utilizar esta conversion de Json a una lista del tipo cPais
            List<cPais> Paises = Newtonsoft.Json.JsonConvert.DeserializeObject<List<cPais>>(Json);
            ViewBag.lstPais = Paises;
            return View();
        }

        //Muestra el país que se a seleccionado en el bombo de la pantalla anterior. 
        public ActionResult MostrarPais(FormCollection form)
        {
            if (form["PaisSeleccionado"] != null)
            {
                var NombrePais = form["PaisSeleccionado"];
                ViewBag.NombrePais = NombrePais;
            }
            else { ViewBag.NombrePais = "No a seleccionado ningún país."; }
            return View("MostrarPais");

        }
    }
}