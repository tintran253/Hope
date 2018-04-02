using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hope.IS4
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

            services.AddIdentityServer()
                    .AddDeveloperSigningCredential()
                    .AddInMemoryClients(new List<Client> {
                        new Client{
                            ClientId = "id_1" ,
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets = {new Secret("secret".Sha256())},
                            AllowedScopes = { "api/composers" }

                        },
                        new Client{
                            ClientId = "id_2" ,
                            AllowedGrantTypes = GrantTypes.ClientCredentials,
                            ClientSecrets = {new Secret("secret".Sha256())},
                            AllowedScopes = { "api/composers" }
                        }
                    })
                    .AddInMemoryIdentityResources(new List<IdentityResource>
                    {
                        new IdentityResource { Name = "A" },
                        new IdentityResource { Name = "B" },
                    })
                    .AddInMemoryApiResources(new List<ApiResource>
                    {
                        new ApiResource("api/composers", "APITTT")
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();

            app.UseMvc();
        }
    }
}
