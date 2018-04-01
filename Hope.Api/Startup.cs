using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hope.Core;
using Hope.Data;
using Hope.Services;
using Hope.WebApi.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hope.Api
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
            services.AddMvc();

            services.AddAuthorization();

            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "http://localhost:5000";
                options.RequireHttpsMetadata = false;

                options.ApiName = "api/composers";
            });


            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => { builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:2503"); }));
            //services.AddSignalR();

            var connection = System.IO.File.ReadAllText("./Settings/SQLSetting.txt");

            //services.AddScoped<IDbContext>(_ => new HopeContext(connection));
            services.AddScoped<IDbContext>(_ => new HopeContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Hope;User ID=sa;Password=Trong@123"));
            //DI
            services.AddScoped<IRepository<Composer>, Repository<Composer>>();
            services.AddScoped<IRepository<Article>, Repository<Article>>();
            services.AddScoped<IRepository<Reader>, Repository<Reader>>();

            services.AddTransient<IComposerService, ComposerService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IReaderService, ReaderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseCors("CorsPolicy");

            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<ChatService>("/chathub");
            //});

            app.UseMvc();
        }
    }
}
