using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = 1;
        }

        public int Id { get; set; }
    }
}
