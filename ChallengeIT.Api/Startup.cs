using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeIT.Data.Contracts;
using ChallengeIT.Data.Models;
using ChallengeIT.Data.Services;
using ChallengeIT.Services.Contracts;
using ChallengeIT.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChallengeIT.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options
                .AddPolicy("AllowAll", 
                    p => p.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient(typeof(ICategoryService), typeof(CategoryService));
            services.AddTransient(typeof(ICategoryData), typeof(CategoryData));
            services.AddTransient(typeof(IPlayerService), typeof(PlayerService));
            services.AddTransient(typeof(IPlayerData), typeof(PlayerData));
            services.AddTransient(typeof(IRankService), typeof(RankService));
            services.AddTransient(typeof(IChallengeService), typeof(ChallengeService));
            services.AddTransient(typeof(IPlayerChallengeData), typeof(PlayerChallengeData));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
