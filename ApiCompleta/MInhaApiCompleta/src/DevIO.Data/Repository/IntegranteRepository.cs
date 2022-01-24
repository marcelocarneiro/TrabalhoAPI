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
    public class IntegranteRepository : Repository<Integrante>, IIntegranteRepository
    {
        public IntegranteRepository(MeuDbContext context) : base(context)
        {

        }


        public async Task<Integrante> ObterItegranteId(int id)
        {
            return await Db.Integrantes.AsNoTracking().
                Include(c => c.Nome).
                FirstOrDefaultAsync(c => c.Id == id);
        }

              
    }
}
