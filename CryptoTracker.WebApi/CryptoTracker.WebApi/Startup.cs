using CryptoTracker.Common;
using CryptoTracker.Common.Interfaces;
using CryptoTracker.Core.DataTransferModels;
using CryptoTracker.Core.ModelMappers;
using CryptoTracker.Core.Services.HistoryService;
using CryptoTracker.Core.Services.PortfolioService;
using CryptoTracker.WebApi.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace CryptoTracker.WebApi
{
    /// <summary>
    /// 
    /// </summary>    
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
            services.AddMvc();

            services.AddEntityFrameworkSqlServer().AddDbContext<CTDbContext>();

            //MySQL support
            //services.AddDbContextPool<CTDbContext>(
            //    options => options.UseMySql("Server=localhost;Database=ef;User=root;Password=123456;", // replace with your Connection String
            //        mysqlOptions =>
            //        {
            //            mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
            //        }
            //));

            services.AddScoped<IEntityMapper, CryptoTrackerEntityMapper>();
            services.AddScoped<IBusinessService<PortfolioDataTransferModel>, PortfolioBusinessService>();
            services.AddScoped<IBusinessService<HistoryLogDataTransferModel>, HistoryBusinessService>();

            services.AddOptions();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,
                                 ValidIssuer = "Fiver.Security.Bearer",
                                 ValidAudience = "Fiver.Security.Bearer",
                                 IssuerSigningKey = JwtSecurityKey.Create("fiversecret ")
                             };
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseAuthentication();
            }

            app.UseMvc();
        }
    }
}
