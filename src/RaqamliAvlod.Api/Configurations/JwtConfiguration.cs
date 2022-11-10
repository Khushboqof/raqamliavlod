using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RaqamliAvlod.Api.Configurations
{
    public static class JwtConfiguration
    {
        public static void ConfigureJwt(this WebApplicationBuilder builder)
        {
            var _config = builder.Configuration.GetSection("Jwt");
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = _config["Issuer"],
                        ValidateAudience = false,
                        //ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key"]))
                    };
                });
        }
    }
}
