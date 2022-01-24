using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IPostService : IDisposable
    {
        Task<bool> Adicionar(Post post);
        Task<bool> Atualizar(Post post);
        Task<bool> Remover(int id);
        
    }
}
