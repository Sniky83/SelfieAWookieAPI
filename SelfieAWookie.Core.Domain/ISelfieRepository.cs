using SelfiesAWookies.Core.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Domain
{
    /// <summary>
    /// Le repertoire pour gérer les selfies
    /// </summary>
    public interface ISelfieRepository : IRepository
    {
        /// <summary>
        /// Récupère tous les selfies
        /// </summary>
        /// <returns></returns>
        ICollection<Selfie> GetAll(int wookieId);
        /// <summary>
        /// Ajoute un selfie en BDD
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Selfie AddOne(Selfie item);
    }
}
