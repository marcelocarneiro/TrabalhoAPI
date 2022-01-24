using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> ObterPostId(int id);
    }
}
