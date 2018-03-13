using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hope.Core;
using Hope.Data;
using Hope.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hope.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public Autofac.IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();


            var connection = @"Server=DESKTOP-BO0G9VS\SQLEXPRESS;Database=Hope;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<HopeContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IRepository<Composer>, Repository<Composer>>();

            services.AddTransient<IComposerService, ComposerService>();


            //// Create the container builder.
            //var builder = new ContainerBuilder();

            //// Register dependencies, populate the services from
            //// the collection, and build the container. If you want
            //// to dispose of the container at the end of the app,
            //// be sure to keep a reference to it as a property or field.
            ////
            //// Note that Populate is basically a foreach to add things
            //// into Autofac that are in the collection. If you register
            //// things in Autofac BEFORE Populate then the stuff in the
            //// ServiceCollection can override those things; if you register
            //// AFTER Populate those registrations can override things
            //// in the ServiceCollection. Mix and match as needed.
            //builder.Populate(services);
            //this.ApplicationContainer = builder.Build();

            //// Create the IServiceProvider based on the container.
            //return new AutofacServiceProvider(this.ApplicationContainer);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
