using Hope.Core;
using Hope.Data;
using Hope.Services;
using Hope.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => { builder.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:2503"); }));
            services.AddSignalR();


            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
                options.AutomaticAuthentication = true;                
            });

            var connection = @"Data Source=.\TINTRAN;Initial Catalog=Hope;User ID=sa;Password=Trong@123";            
            //services.AddDbContext<HopeContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IRepository<Composer>, Repository<Composer>>();
            services.AddScoped<IRepository<Article>, Repository<Article>>();
            services.AddScoped<IRepository<Reader>, Repository<Reader>>();

            services.AddTransient<IComposerService, ComposerService>();
            services.AddTransient<IArticleService, ArticleService>();
            services.AddTransient<IReaderService, ReaderService>();
            //services.AddTransient<ICommentService, CommentService>();
            //services.AddTransient<IComposerService, ComposerService>();


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

            app.UseCors("CorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });

            app.UseMvc();
        }
    }
}
