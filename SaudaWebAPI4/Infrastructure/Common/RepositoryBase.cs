using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Common
{
    public abstract class RepositoryBase<T> where T : class
    {
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
    }
}