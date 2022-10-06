using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfiesAWookies.Core.Framework
{
    /// <summary>
    /// Utile pour définir la class comme répository
    /// </summary>
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
