using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EAutoSkola.EF;
using Microsoft.EntityFrameworkCore;
using EAutoSkola.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ReflectionIT.Mvc;
using ReflectionIT;
using ReflectionIT.Mvc.Paging;
using EAutoSkola.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;


namespace EAutoSkola
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            //SignalR
            services.AddSignalR(); 
            services.AddControllersWithViews();
            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("connectionpc")));
            //Repository
            services.AddScoped<IKategorijaRepository, KategorijaRepository>();
            services.AddScoped<ILjekarskoUvjerenje, LjekarskoRepository>();
            services.AddScoped<IRasporedCasovaRepository, RasporedCasovaRepository>();
            services.AddScoped<IUslugeRepository,UslugeRepository>();
            services.AddScoped<IvozilaRepository, VozilaRepository>();
            services.AddScoped<IZahtjevRepository, ZahtjeviRepository>();
            services.AddScoped<IUplateRepository, UplateRepository>();
            services.AddScoped<IKandidatiRepository, KandidatiRepository>();
            services.AddScoped<IUposlenikTipUposlenika, UposlenikTipUposlenikaRepository>();
            services.AddScoped<IUposleniciRepository, UposleniciRepository>();
            services.AddScoped<IRasporedCasovaRepository, RasporedCasovaRepository>();
            services.AddScoped<ITerminRasporedaCasova, TerminRasporedaCasovaRepository>();
            services.AddScoped<ISatnicaRepository, SatnicaRepository>();
            services.AddScoped<IPlataRepository, PlataRepository>();
            services.AddScoped<IPotvrdaRepository, PotvrdaRepository>();
            services.AddScoped<ITipUposlenika, TipUposlenikaRepository>();
            services.AddScoped<IRasporedPolaganjaRepository, RasporedPolaganjaRepository>();
            services.AddScoped<ITerminRasporedPolaganjaRepository, TerminRasporedPolaganjaRepository>();

            //Paging
            services.AddMvc();
            services.AddPaging();
            //Autientifikacija
            //Obuhvata klase za manipulaciju sa korisnicima (Korisnik)
            services.AddIdentity<Korisnik,Rola>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
            })
                //Dodavanje UserStore i RoleStore, koje će koristiti Korisnik i Rola
                .AddEntityFrameworkStores<MyContext>()
              
            //Dodavanje provajdera za generisanje jedinstvenih ključeva i heševa za zaboravljene šifre
                .AddDefaultTokenProviders();
            //Bez ovog nije radilo prepoznavanje lozinke
            services.Configure<PasswordHasherOptions>(options =>
               options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
            );
            //services.AddMvc(options =>
            //{
            //    var policy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build()
            //    .options.Filters.Add(new AuthorizeFilter(policy));
            //}).AddXmlSerializerFormatters();
           

            ////Password pravila
            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 5;
            //});

            services.AddRazorPages().AddMvcOptions(option => option.EnableEndpointRouting = false);
           
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<MyContext>();
            //services.AddIdentity<Korisnik, IdentityRole>()
            //    .AddEntityFrameworkStores<MyContext>();
              
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
         

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            //ko si ti?
            app.UseAuthentication();
            //sta ti je dozvoljeno
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                            name: "default",
                            pattern: "{controller=Autentifikacija}/{action=Login}/{id?}"
                        );
                }
            );
            



        }
    }
}

