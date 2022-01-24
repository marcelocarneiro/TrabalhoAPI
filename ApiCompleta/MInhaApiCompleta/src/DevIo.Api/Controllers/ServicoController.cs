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
    
    [Route("api/servicos")]
    public class ServicoController : MainController
    {
        private readonly IServicoRepository _servicoRepository;
        private readonly IMapper _mapper;
        private readonly IServicoService _servicoService;

        public ServicoController(IServicoRepository servicoRepository,
                                      IServicoService servicoService,
                                      IMapper mapper,
                                      INotificador notificador) : base(notificador)
        {
            _servicoRepository = servicoRepository;
            _mapper = mapper;
            _servicoService = servicoService;
        }


        [HttpGet]
        public async Task<IEnumerable<ServicoViewModel>> ObterTodos()
        {
            var servico = _mapper.Map<IEnumerable<ServicoViewModel>>(await _servicoRepository.ObterTodos());
            return servico;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicoViewModel>> ObterPorId(int id)
        {
            var servico = _mapper.Map<ServicoViewModel>(await _servicoRepository.ObterServicoId(id));

            if (servico == null) return NotFound();

            return servico;
        }

        [HttpPost]
        public async Task<ActionResult<ServicoViewModel>> Adicionar(ServicoViewModel ServicoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _servicoService.Adicionar(_mapper.Map<Servico>(ServicoViewModel));

            return CustomResponse(ServicoViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ServicoViewModel>> Atualizar(int id, ServicoViewModel ServicoViewModel)
        {
            if (id != ServicoViewModel.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na consulta.");
                return CustomResponse(ServicoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _servicoService.Atualizar(_mapper.Map<Servico>(ServicoViewModel));           

            return CustomResponse(ServicoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ServicoViewModel>> Excluir(int id)
        {
            var ServicoViewModel = await ObterPorId(id);

            if (ServicoViewModel == null) return NotFound();

            await _servicoService.Remover(id);            

            return CustomResponse(ServicoViewModel); 
        }

        

    }
}
