using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace CosmeticWebApp
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
            //JWT
            //services.AddCors(option => { option.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials().Build());});
            services.AddCors(option => { option.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build()); });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters //?
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc(); //Có thể bỏ
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            #region -- Swagger --            
            var inf1 = new OpenApiInfo
            {
                Title = "API v1.0",
                Version = "v1",
                Description = "Swashbuckle",
                TermsOfService = new Uri("http://appointvn.com"),
                Contact = new OpenApiContact
                {
                    Name = "Chàng trai đôn chề",
                    Email = "vietlentrencat_elamnattraitima@yahoo.com.vn"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                }
            };

            var inf2 = new OpenApiInfo
            {
                Title = "API v2.0",
                Version = "v2",
                Description = "Swashbuckle",
                TermsOfService = new Uri("http://appointvn.com"),
                Contact = new OpenApiContact
                {
                    Name = "Chàng trai đôn chề",
                    Email = "vietlentrencat_elamnattraitima@yahoo.com.vn"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                }
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", inf1);
                c.SwaggerDoc("v2", inf2);
            });
            #endregion

            //Add session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(3600); //Timeout
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Use sesion created above
            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region -- Swagger --
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1.0");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2.0");
            });
            #endregion

            //app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            //app.UseCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseCors("CorsPolicy");
            //app.UseCors(config =>
            //    config.AllowAnyOrigin()
            //          .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //JWT
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
