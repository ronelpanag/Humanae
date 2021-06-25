using Humanae.Contracts;
using Humanae.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Humanae.Repositories
{
    public class DeletableRepository<T> where T : IDeletableEntity 
    {
        private readonly ApplicationDbContext Context = new ApplicationDbContext();

        //public async Task Delete(T input)
        //{
        //    input.IsActive = false;

        //    Context.
        //}
    }
}
