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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(MeuDbContext context) : base(context)
        {

        }


        public async Task<Post> ObterPostId(int id)
        {
            return await Db.Posts.AsNoTracking().
                Include(c => c.Texto).
                FirstOrDefaultAsync(c => c.Id == id);
        }

        
    }
}
