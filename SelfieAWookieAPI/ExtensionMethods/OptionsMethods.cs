using SelfieAWookie.Core.Selfies.Infrastructures.Configurations;

namespace SelfieAWookieAPI.ExtensionMethods
{
    /// <summary>
    /// Options personnalisées pour la config (json)
    /// </summary>
    public static class OptionsMethods
    {
        #region Public Methods
        /// <summary>
        /// Ajoute des Options personnalisées pour la config (json)
        /// </summary>
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
            services.Configure<CorsOption>(configuration.GetSection("Cors"));
        }
        #endregion
    }
}
