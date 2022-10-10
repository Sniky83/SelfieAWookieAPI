namespace SelfieAWookieAPI.ExtensionMethods
{
    /// <summary>
    /// Mise en place de la sécurité avec la notion de CORS et JWT.
    /// </summary>
    public static class SecurityMethods
    {
        #region Constants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2";
        public const string DEFAULT_POLICY_3 = "DEFAULT_POLICY_3";
        #endregion

        #region Public Methods
        /// <summary>
        /// Ajout la configuration CORS et JWT
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(configuration["Cors:Origin"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
                
                options.AddPolicy(DEFAULT_POLICY_2, builder =>
                {
                    builder.WithOrigins(configuration["Cors:Origin2"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });

                options.AddPolicy(DEFAULT_POLICY_3, builder =>
                {
                    builder.WithOrigins(configuration["Cors:Origin3"])
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
        #endregion
    }
}
