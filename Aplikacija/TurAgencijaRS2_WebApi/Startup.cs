using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using TurAgencijaRS2_Model.Requests;
using TurAgencijaRS2_WebApi.Database;
using TurAgencijaRS2_WebApi.Filters;
using TurAgencijaRS2_WebApi.Security;
using TurAgencijaRS2_WebApi.Services;

namespace TurAgencijaRS2_WebApi
{
    public class Startup
    {

        public class BasicAuthDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

                swaggerDoc.Security = new[] { securityRequirements };
            }
        }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }








        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");

                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddMvc(x=>x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper();

            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });


            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IService<TurAgencijaRS2_Model.Regije, object>, BaseService<TurAgencijaRS2_Model.Regije,object,Regije>>();

            services.AddScoped<IService<TurAgencijaRS2_Model.Zaposlenici, object>, BaseService<TurAgencijaRS2_Model.Zaposlenici, object, Zaposlenici>>();

            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Gradovi, GradoviSearchRequest,GradoviUpsertRequest,GradoviUpsertRequest>, GradoviService>();


            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Putovanja, object, RezervacijeUpsertRequests, RezervacijeUpsertRequests>, BaseCRUDService<TurAgencijaRS2_Model.Putovanja,object,Putovanja,RezervacijeUpsertRequests,RezervacijeUpsertRequests>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Ponude, object, PonudeUpsertRequest, PonudeUpsertRequest>, BaseCRUDService<TurAgencijaRS2_Model.Ponude, object, Ponude, PonudeUpsertRequest, PonudeUpsertRequest>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Zaduzenja, object, ZaduzenjaUpsertRequest, ZaduzenjaUpsertRequest>, BaseCRUDService<TurAgencijaRS2_Model.Zaduzenja, object, Zaduzenja, ZaduzenjaUpsertRequest, ZaduzenjaUpsertRequest>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Recenzije, object, RecenzijeUpsertRequest, RecenzijeUpsertRequest>, BaseCRUDService<TurAgencijaRS2_Model.Recenzije, object, Recenzije, RecenzijeUpsertRequest, RecenzijeUpsertRequest>>();


            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Rezervacije, object, RecenzijeUpsertrequest, RecenzijeUpsertrequest>, BaseCRUDService<TurAgencijaRS2_Model.Rezervacije, object, Rezervacije, RecenzijeUpsertrequest, RecenzijeUpsertrequest>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Zaposlenici, object, ZaposleniciUpsertRequest, ZaposleniciUpsertRequest>, BaseCRUDService<TurAgencijaRS2_Model.Zaposlenici, object, Zaposlenici, ZaposleniciUpsertRequest, ZaposleniciUpsertRequest>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.KontaktPodaci, object, KontaktPodaciInserRequest, KontaktPodaciInserRequest>, BaseCRUDService<TurAgencijaRS2_Model.KontaktPodaci, object, KontaktPodaci, KontaktPodaciInserRequest, KontaktPodaciInserRequest>>();



            services.AddScoped<ICRUDService<TurAgencijaRS2_Model.Turisti, object, TuristiInsertRequest, TuristiInsertRequest>, BaseCRUDService<TurAgencijaRS2_Model.Turisti, object, Turisti, TuristiInsertRequest, TuristiInsertRequest>>();


            var connection = @"Server=.;Database=TuristickaAgencija_RS2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<TuristickaAgencija_RS2Context>(options => options.UseSqlServer(connection));

        }













        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });

            app.UseAuthentication();
            // app.UseHttpsRedirection();


            app.UseCors(MyAllowSpecificOrigins);

            app.UseMvc();


        }
    }
}
