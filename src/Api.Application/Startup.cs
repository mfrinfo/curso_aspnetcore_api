using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Application {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            ConfigureService.ConfigureDependenciesService (services);
            ConfigureRepository.ConfigureDependenciesRepository (services);

            services.AddSwaggerGen (c => {
                c.SwaggerDoc ("v1",
                    new Info {
                        Title = "Curso de AspNetCore 2.2",
                            Version = "v1",
                            Description = "Exemplo de API REST criada com o ASP.NET Core",
                            Contact = new Contact {
                                Name = "Marcos Fabricio Rosa",
                                    Url = "https://github.com/mfrinfo"
                            }
                    });
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger ();
            app.UseSwaggerUI (c => {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Curso de API com AspNetCore 2.2");
            });

            // Redireciona o Link para o Swagger, quando acessar a rota principal
            var option = new RewriteOptions ();
            option.AddRedirect ("^$", "swagger");
            app.UseRewriter (option);

            app.UseMvc ();
        }
    }
}
