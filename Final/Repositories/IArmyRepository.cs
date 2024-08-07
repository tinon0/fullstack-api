using Practica_Final.Models;

namespace Practica_Final.Repositories
{
    public interface IArmyRepository
    {
        Task<List<Escuadron>> GetEscuadrones();
        //Task<SoldadoXEscuadron> PostSoldadoxEscuadron(Guid idSol, Guid idEsc, string act);
        Task<SoldadoXEscuadron> PostSoldadoxEscuadron(SoldadoXEscuadron soldadoXEscuadron);
        //Task<Soldado> PostSoldado(string nom, string ape, float alt, float peso, string loc);
        Task<Soldado> PostSoldado(Soldado soldado);
        Task<List<Soldado>> GetSoldados(Guid idEsc);

        Task<string> GetNombreSoldado(Guid idSoldado);
        Task<string> GetNombreEscuadron(Guid idEscuadron);
    }
}
