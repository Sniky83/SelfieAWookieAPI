using MediatR;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;

namespace SelfieAWookieAPI.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public Methods
        /// <summary>
        /// Prepare l'injection de dépendance personnalisée.
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
            services.AddMediatR(typeof(Program));

            return services;
        }
        #endregion
    }
}
