using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LotterySyndicate.API.Entities;
using LotterySyndicate.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace LotterySyndicate.API
{
    public class Startup
    {
        //public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public static IConfigurationRoot Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var connectionString = Startup.Configuration["connectionStrings:lotterySyndicateDbConnectionString"];
            services.AddDbContext<LotterySyndicateContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<ILotterySyndicateRepository, LotterySyndicateRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, LotterySyndicateContext lotterySyndicateContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            
            lotterySyndicateContext.EnsureSeedForContext();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.LotteryTicket, Models.LotteryTicketDto>();
                cfg.CreateMap<Entities.LotteryLine, Models.LotteryLineDto>();
                cfg.CreateMap<Entities.LotteryNumber, Models.LotteryNumberDto>();
                cfg.CreateMap<Models.LotteryTicketForCreationDto, Entities.LotteryTicket>();
            });

            app.UseMvc();
        }
    }
}
