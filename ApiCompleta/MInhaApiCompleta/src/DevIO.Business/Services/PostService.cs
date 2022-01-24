using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;


namespace DevIO.Business.Services
{
    public class PostService : BaseService, IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository,
                                 INotificador notificador) : base(notificador)
        {
            _postRepository = postRepository;
        }

        public async Task<bool> Adicionar(Post post)
        {
            await _postRepository.Adicionar(post);
            return true;
        }

        public async Task<bool> Atualizar(Post post)
        {          
            await _postRepository.Atualizar(post);
            return true;
        }       

        public async Task<bool> Remover(int id)
        {  
            await _postRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _postRepository?.Dispose();
            
        }
    }
}

