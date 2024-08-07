using Practica_Final.Comandos;
using Practica_Final.DTO;
using Practica_Final.Resultado;

namespace Practica_Final.Services
{
    public interface IArmyService
    {
        Task<List<ResultadoBase>> GetEscuadrones();
        //Task<SoldadoXEscuadronDTO> PostSoldadoxEscuadron(Guid idSol, Guid idEsc, string act);
        Task<ResultadoBase> PostSoldadoxEscuadron(NuevoSoldadoXEscuadron nuevoSoldadoXEscuadron);
        //Task<SoldadoDTO> PostSoldado(string nom, string ape, float alt, float peso, string loc);
        Task<ResultadoBase> PostSoldado(NuevoSoldado nuevoSoldado);
        Task<ResultadoBase> GetSoldados(Guid idEsc);
    }
}
