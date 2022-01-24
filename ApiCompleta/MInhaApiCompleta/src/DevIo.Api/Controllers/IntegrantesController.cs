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
    
    [Route("api/integrantes")]
    public class IntegrantesController : MainController
    {
        private readonly IIntegranteRepository _integranteRepository;
        private readonly IMapper _mapper;
        private readonly IIntegranteService _integranteService;

        public IntegrantesController(IIntegranteRepository integranteRepository,
                                      IIntegranteService integranteService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _integranteRepository = integranteRepository;
            _mapper = mapper;
            _integranteService = integranteService;
        }


        [HttpGet]
        public async Task<IEnumerable<IntegranteViewModel>> ObterTodos()
        {
            var integrante = _mapper.Map<IEnumerable<IntegranteViewModel>>(await _integranteRepository.ObterTodos());

            return integrante;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IntegranteViewModel>> ObterPorId(int id)
        {
            var integrante = _mapper.Map<IntegranteViewModel>(await _integranteRepository.ObterItegranteId(id));

            if (integrante == null) return NotFound();

            return integrante;
        }

        [HttpPost]
        public async Task<ActionResult<IntegranteViewModel>> Adicionar(IntegranteViewModel integranteViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _integranteService.Adicionar(_mapper.Map<Integrante>(integranteViewModel));

            return CustomResponse(integranteViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IntegranteViewModel>> Atualizar(int id, IntegranteViewModel integranteViewModel)
        {
            if (id != integranteViewModel.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na consulta.");
                return CustomResponse(integranteViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _integranteService.Atualizar(_mapper.Map<Integrante>(integranteViewModel));           

            return CustomResponse(integranteViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IntegranteViewModel>> Excluir(int id)
        {
            var integranteViewModel = await ObterPorId(id);

            if (integranteViewModel == null) return NotFound();

            await _integranteService.Remover(id);            

            return CustomResponse(integranteViewModel); 
        }

        

    }
}
