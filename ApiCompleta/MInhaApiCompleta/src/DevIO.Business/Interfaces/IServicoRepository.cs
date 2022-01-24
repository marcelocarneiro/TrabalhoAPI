using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IServicoRepository : IRepository<Servico>
    {
        Task<Servico> ObterServicoId(int id);
    }
}
