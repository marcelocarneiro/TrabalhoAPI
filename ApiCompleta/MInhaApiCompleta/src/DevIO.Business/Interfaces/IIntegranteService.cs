using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IIntegranteService : IDisposable
    {
        Task<bool> Adicionar(Integrante integrante);
        Task<bool> Atualizar(Integrante integrante);
        Task<bool> Remover(int id);
        
    }
}
