using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Microsoft.EntityFrameworkCore;
using Data.Repositories.Interfaces;
using Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Infra.Dependeces
{
    public static class ServicesDependeces
    {

        public static IServiceCollection ConfigurationDatabaseProject(this IServiceCollection services)
        {
            //var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

            services.AddDbContext<AppDbContext>(options => options.UseNpgsql("server=localhost;Id=root;password=123456;database=upa"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            return services;
        }
        public static IServiceCollection RepositoriesDependeces(this IServiceCollection services)
        {
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

            return services;

        }



    }
}
