using AutoMapper;
using Microsoft.VisualBasic;
using Practica_Final.Comandos;
using Practica_Final.DTO;
using Practica_Final.Models;
using Practica_Final.Repositories;
using Practica_Final.Resultado;
using Practica_Final.Validations;

namespace Practica_Final.Services.Impl
{
    public class ArmyService : IArmyService
    {
        private readonly IArmyRepository _armyRepository;
        private readonly IMapper _mapper;
        private readonly SoldadoValidator _soldadoValidator;
        private readonly SoldadoXEscuadronValidator _soldadoXEscuadronValidator;
        public ArmyService(IArmyRepository _armyRepository, IMapper _mapper, SoldadoValidator _soldadoValidator, SoldadoXEscuadronValidator _soldadoXEscuadronValidator)
        {
            this._armyRepository = _armyRepository;
            this._mapper = _mapper;
            this._soldadoValidator = _soldadoValidator;
            this._soldadoXEscuadronValidator = _soldadoXEscuadronValidator;
        }
        public async Task<ResultadoBase> GetEscuadrones()
        {
            var resultado = new ResultadoBase();
            try
            {
                var escuadrones = await _armyRepository.GetEscuadrones();
                if(escuadrones == null)
                {
                    resultado.Error = "Error: Escuadrones nulos";
                    resultado.MensajeInfo = "No se encontraron escuadrones";
                    resultado.Ok = false;
                    resultado.StatusCode = 500;
                    resultado.Resultado = null;
                    return resultado;
                }
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se encontraron escuadrones";
                resultado.Ok = true;
                resultado.StatusCode = 200;

                var escuadronesDto = _mapper.Map<List<EscuadronDTO>>(escuadrones);

                resultado.Resultado = escuadronesDto;
                
            }
            catch (Exception ex)
            {
                resultado.Error = "Error";
                resultado.MensajeInfo = ex.Message;
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            return resultado;
        }

        public async Task<ResultadoBase> GetSoldados(Guid idEsc)
        {
            var resultado = new ResultadoBase();
            try
            {
                var soldados = await _armyRepository.GetSoldados(idEsc);
                if (soldados == null)
                {
                    resultado.Error = "Error: Solado nulo";
                    resultado.MensajeInfo = "No se encontro el soldado";
                    resultado.Ok = false;
                    resultado.StatusCode = 500;
                    resultado.Resultado = null;
                    return resultado;
                }
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se encontraron escuadrones";
                resultado.Ok = true;
                resultado.StatusCode = 200;

                var soldadosDto = _mapper.Map<List<SoldadoDTO>>(soldados);

                resultado.Resultado = soldadosDto;

            }
            catch (Exception ex)
            {
                resultado.Error = "Error";
                resultado.MensajeInfo = ex.Message;
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            return resultado;
        }

        //public async Task<SoldadoDTO> PostSoldado(string nom, string ape, float alt, float peso, string loc)
        //{
        //    var soldado = await _armyRepository.PostSoldado(nom, ape, alt, peso, loc);
        //    var soldadoDto = _mapper.Map<SoldadoDTO>(soldado);
        //    return soldadoDto;
        //}

        public async Task<ResultadoBase> PostSoldado(NuevoSoldado nuevoSoldado)
        {
            var resultado = new ResultadoBase();
            var validacion = await _soldadoValidator.ValidateAsync(nuevoSoldado);
            if (!validacion.IsValid)
            {
                var erroMsg = string.Join(", ", validacion.Errors.Select(x => x.ErrorMessage));
                resultado.Error = "Error";
                resultado.MensajeInfo = erroMsg;
                resultado.Ok = false;
                resultado.StatusCode = 500;
                return resultado;
            }
            try
            {
                var soldado = new Soldado();
                var escuadrones = await _armyRepository.GetEscuadrones();
                if (escuadrones == null)
                {
                    resultado.Error = "Error: Escuadrones nulos";
                    resultado.MensajeInfo = "No se encontraron escuadrones";
                    resultado.Ok = false;
                    resultado.StatusCode = 500;
                    resultado.Resultado = null;
                    return resultado;
                }
                resultado.Error = "NONE";
                resultado.MensajeInfo = "Se encontraron escuadrones";
                resultado.Ok = true;
                resultado.StatusCode = 200;

                var escuadronesDto = _mapper.Map<List<EscuadronDTO>>(escuadrones);

                resultado.Resultado = escuadronesDto;

            }
            catch (Exception ex)
            {
                resultado.Error = "Error";
                resultado.MensajeInfo = ex.Message;
                resultado.Ok = false;
                resultado.StatusCode = 500;
                resultado.Resultado = null;
            }
            return resultado;
        }

        //public async Task<SoldadoXEscuadronDTO> PostSoldadoxEscuadron(Guid idSol, Guid idEsc, string act)
        //{
        //    var soldadoXEscuadron = await _armyRepository.PostSoldadoxEscuadron(idSol, idEsc, act);
        //    var soldadoXEscuadronDto = _mapper.Map<SoldadoXEscuadronDTO>(soldadoXEscuadron);
        //    soldadoXEscuadronDto.NombreEscuadron = await _armyRepository.GetNombreEscuadron(idEsc);
        //    soldadoXEscuadronDto.NombreSoldado = await _armyRepository.GetNombreSoldado(idSol);
        //    return soldadoXEscuadronDto;
        //}

        public Task<SoldadoXEscuadronDTO> PostSoldadoxEscuadron(SoldadoXEscuadronDTO soldadoXEscuadronDTO)
        {
            throw new NotImplementedException();
        }
    }
}
