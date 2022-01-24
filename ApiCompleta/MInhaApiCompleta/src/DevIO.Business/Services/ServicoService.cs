using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;


namespace DevIO.Business.Services
{
    public class ServicoService : BaseService, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository,
                                 INotificador notificador) : base(notificador)
        {
            _servicoRepository = servicoRepository;
        }

        public async Task<bool> Adicionar(Servico servico)
        {
            await _servicoRepository.Adicionar(servico);
            return true;
        }

        public async Task<bool> Atualizar(Servico servico)
        {          
            await _servicoRepository.Atualizar(servico);
            return true;
        }       

        public async Task<bool> Remover(int id)
        {  
            await _servicoRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _servicoRepository?.Dispose();
            
        }
    }
}

