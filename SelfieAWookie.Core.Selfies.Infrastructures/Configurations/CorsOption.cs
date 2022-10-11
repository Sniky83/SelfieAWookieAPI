using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Infrastructures.Configurations
{
    /// <summary>
    /// Option pour configurer la sécurité du CORS
    /// </summary>
    public class CorsOption
    {
        #region Properties
        public string Origin { get; set; }
        public string Origin2 { get; set; }
        public string Origin3 { get; set; }
        #endregion
    }
}
