using Microsoft.AspNetCore.Mvc;
using Practica_Final.Comandos;
using Practica_Final.Resultado;
using Practica_Final.Services;

namespace Practica_Final.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class HomeController : ControllerBase
    {
        private readonly IArmyService _armyService;
        public HomeController(IArmyService _armyService)
        {
            this._armyService = _armyService;
        }
        [HttpGet]
        [Route("/getEscuadrones")]
        public async Task<ResultadoBase> GetEscuadrones()
        {
            var resultado = new ResultadoBase();
            resultado.Error = "NONE";
            resultado.MensajeInfo = "Se encontraron Escuadrones";
            resultado.Ok = true;
            resultado.StatusCode = 200;
            resultado.Resultado = await _armyService.GetEscuadrones();

            return resultado;
        }
        [HttpPost]
        [Route("/postSoldadoXEscuadron")]
        public async Task<ResultadoBase> PostSoldadoXEscuadron(NuevoSoldadoXEscuadron nuevoSoldadoEscuadron)
        {
            var resultado = new ResultadoBase();
            //HACER LA VALIDACION CON FLUENTVALIDATION ACA

            if (nuevoSoldadoEscuadron.IdEscuadron.Equals("")) 
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "ID del Escuadron no puede ser nulo";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;

            }
            if (nuevoSoldadoEscuadron.IdSoldado.Equals(""))
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "ID del Soldado no puede ser nulo";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            if (nuevoSoldadoEscuadron.Actividad.Equals(""))
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "La Actividad no puede ser nulo";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            resultado.Error = "NONE";
            resultado.MensajeInfo = "Se asigno el soldado al escuadron correctamente";
            resultado.Ok = true;
            resultado.StatusCode = 200;
            resultado.Resultado = await _armyService.PostSoldadoxEscuadron(nuevoSoldadoEscuadron.IdSoldado, nuevoSoldadoEscuadron.IdEscuadron, nuevoSoldadoEscuadron.Actividad);
            return resultado;
        }
        [HttpPost]
        [Route("/postSoldado")]
        public async Task<ResultadoBase> PostSoldado(NuevoSoldado nuevoSoldado)
        {
            var resultado = new ResultadoBase();

            if(nuevoSoldado.Altura == 0
                ||
                nuevoSoldado.Apellido.Equals(string.Empty)
                ||
                nuevoSoldado.Localidad.Equals(string.Empty)
                ||
                nuevoSoldado.Nombre.Equals(string.Empty)
                ||
                nuevoSoldado.Peso == 0)
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "Hay campos nulos";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
                return resultado;
            }
            resultado.Error = "NONE";
            resultado.MensajeInfo = "Se creo el Soldado correctamente";
            resultado.Ok = true;
            resultado.StatusCode = 200;
            resultado.Resultado = await _armyService.PostSoldado(nuevoSoldado.Nombre, nuevoSoldado.Apellido, nuevoSoldado.Altura, nuevoSoldado.Peso, nuevoSoldado.Localidad);
            return resultado;
        }
        [HttpGet]
        [Route("/getSoldados/{idEscuadron}")]
        public async Task<ResultadoBase> GetSoldados(Guid idEscuadron)
        {
            var resultado = new ResultadoBase();

            if (idEscuadron.Equals(""))
            {
                resultado.Error = "ERROR";
                resultado.MensajeInfo = "ID Escuadron es nulo";
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            resultado.Error = "NONE";
            resultado.MensajeInfo = "Se encontro los Soldado correctamente";
            resultado.Ok = true;
            resultado.StatusCode = 200;
            resultado.Resultado = await _armyService.GetSoldados(idEscuadron);
            return resultado;
        }
    }
}
