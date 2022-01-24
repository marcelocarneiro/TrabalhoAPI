using AutoMapper;
using DevIo.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Api.Controllers
{
    
    [Route("api/posts")]
    public class PostController : MainController
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostController(IPostRepository postRepository,
                                      IPostService postService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _postService = postService;
        }


        [HttpGet]
        public async Task<IEnumerable<PostViewModel>> ObterTodos()
        {
            var post = _mapper.Map<IEnumerable<PostViewModel>>(await _postRepository.ObterTodos());

            return post;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostViewModel>> ObterPorId(int id)
        {
            var post = _mapper.Map<PostViewModel>(await _postRepository.ObterPostId(id));

            if (post == null) return NotFound();

            return post;
        }

        [HttpPost]
        public async Task<ActionResult<PostViewModel>> Adicionar(PostViewModel postViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _postService.Adicionar(_mapper.Map<Post>(postViewModel));

            return CustomResponse(postViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PostViewModel>> Atualizar(int id, PostViewModel postViewModel)
        {
            if (id != postViewModel.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na consulta.");
                return CustomResponse(postViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _postService.Atualizar(_mapper.Map<Post>(postViewModel));           

            return CustomResponse(postViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PostViewModel>> Excluir(int id)
        {
            var postViewModel = await ObterPorId(id);

            if (postViewModel == null) return NotFound();

            await _postService.Remover(id);            

            return CustomResponse(postViewModel); 
        }

        

    }
}
