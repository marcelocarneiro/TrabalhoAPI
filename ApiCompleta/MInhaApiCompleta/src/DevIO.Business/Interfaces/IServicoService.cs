using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IServicoService : IDisposable
    {
        Task<bool> Adicionar(Servico servico);
        Task<bool> Atualizar(Servico servico);
        Task<bool> Remover(int id);
        
    }
}
