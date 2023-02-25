using AccesoDatos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIBooton.Controllers
{
    public class BootonController : ApiController
    {
        [HttpGet]
        public List<ReponseSearch> GetDataSearch(string prmBusqueda)
        {           
            return new AccesoDatos.AccesoDatos().ObtenerResultladosBusqueda(prmBusqueda);
        }
    }
}
