using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IIntegranteRepository : IRepository<Integrante>
    {
        Task<Integrante> ObterItegranteId(int id);
    }
}
