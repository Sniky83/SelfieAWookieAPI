using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Selfies.Infrastructures.Configurations;
using System.Text;

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
                options.AddCustomCors(configuration);
            });

            services.AddCustomAuthentication(configuration);
        }
        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            SecurityOption securityOption = new SecurityOption();
            configuration.GetSection("Jwt").Bind(securityOption);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                string maClef = securityOption.Key;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(maClef)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true
                };
            });
        }

        public static void AddCustomCors(this CorsOptions options, IConfiguration configuration)
        {
            CorsOption corsOption = new CorsOption();
            configuration.GetSection("Cors").Bind(corsOption);

            options.AddPolicy(DEFAULT_POLICY, builder =>
            {
                builder.WithOrigins(corsOption.Origin)
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });

            options.AddPolicy(DEFAULT_POLICY_2, builder =>
            {
                builder.WithOrigins(corsOption.Origin2)
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });

            options.AddPolicy(DEFAULT_POLICY_3, builder =>
            {
                builder.WithOrigins(corsOption.Origin3)
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        }
        #endregion
    }
}
