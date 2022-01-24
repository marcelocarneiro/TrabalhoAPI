using DevIO.Business.Models;
using DevIO.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository
{
    public class ServicoRepository : Repository<Servico>, IServicoRepository
    {
        public ServicoRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Servico> ObterServicoId(int id)
        {
            return await Db.Servicos.AsNoTracking().
                Include(c => c.Descricao).
                FirstOrDefaultAsync(c => c.Id == id);
        }

              
    }
}
