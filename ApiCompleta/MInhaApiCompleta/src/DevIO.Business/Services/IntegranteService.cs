using System;
using System.Linq;
using System.Threading.Tasks;
using DevIO.Business.Intefaces;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;


namespace DevIO.Business.Services
{
    public class IntegranteService : BaseService, IIntegranteService
    {
        private readonly IIntegranteRepository _integranteRepository;

        public IntegranteService(IIntegranteRepository integranteRepository,
                                 INotificador notificador) : base(notificador)
        {
            _integranteRepository = integranteRepository;
        }

        public async Task<bool> Adicionar(Integrante integrante)
        {
            await _integranteRepository.Adicionar(integrante);
            return true;
        }

        public async Task<bool> Atualizar(Integrante integrante)
        {          
            await _integranteRepository.Atualizar(integrante);
            return true;
        }       

        public async Task<bool> Remover(int id)
        {  
            await _integranteRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _integranteRepository?.Dispose();
            
        }

    }
}

