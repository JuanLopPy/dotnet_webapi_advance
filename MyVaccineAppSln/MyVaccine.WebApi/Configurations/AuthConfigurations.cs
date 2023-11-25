using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations
{
    public static class AuthConfigurations
    {
        public static IServiceCollection setMyVaccineAuthConfiguration (this IServiceCollection services)

        { 
            services.AddIdentity<IdentityUser, IdentityRole> (Options =>
        
              { 
                  Options.Password.RequireDigit = true;
                  Options.Password.RequireUppercase = true;
                  Options.Password.RequireLowercase = true;
                  Options.Password.RequiredLength= 8;

              }).AddEntityFrameworkStores<MyVaccineAppDbContext>()
             .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options => {

                options.TokenValidationParameters = new TokenValidationParameters
                { 
                 ValidateIssuer= true,
                
                 ValidateAudience=true,

                 ValidateLifetime=true,

                 ValidateIssuerSigningKey=true,
                 

                };
            });


            return services;
        }
    }
}
