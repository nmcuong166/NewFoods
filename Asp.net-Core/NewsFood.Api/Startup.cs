using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NewsFood.Infurstructure.Data.Entities;
using NewsFood.Infurstructure.Data.EntityFramework;
using Swashbuckle.AspNetCore.Swagger;
using NewsFood.Infurstructure.Data.Mapping;
using System.Text;
using NewsFood.Infurstructure.Data;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;

namespace NewsFood.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        private ILogger<Startup> _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes("SOME_RANDOM_KEY_DO_NOT_SHARE");

            //services.AddHsts(options => {
            //    options.Preload = true;
            //    options.IncludeSubDomains = true;
            //    options.MaxAge = TimeSpan.FromDays(60);
            //    options.ExcludedHosts.Add("example.com");
            //    options.ExcludedHosts.Add("www.example.com");
            //});

            //services.AddHttpsRedirection(options =>
            //{
            //    options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
            //    options.HttpsPort = 5001;
            //});

            //this service sets connect database from appsettings.json
            //var optionBuilder = services.AddDbContext<ApplicationDbContext>((option) =>
            //{
            //    var a = option.UseSqlServer(Configuration["Data:NewsFood:ConnectionString"]);
            //    if (Environment.IsDevelopment())
            //    {
            //        option.EnableSensitiveDataLogging();
            //    }
            //}, ServiceLifetime.Singleton);

            var optionBuilder = services.AddDbContext<ApplicationDbContext>((option) =>
            {
                var a = option.UseMySql(Configuration["Data:NewsFood:MySQLConnectionString"]);
                if (Environment.IsDevelopment())
                {
                    option.EnableSensitiveDataLogging();
                }
            }, ServiceLifetime.Singleton);

            //this services sets Identity
            services.AddIdentity<AppUsers, AppRoles>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            //this services set JWT Token 
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //this services register DI
            services.DIServiceExtension();
            //Register AutoMapper for file DataProfiles in project Infurstructure
            services.AddAutoMapper(typeof(DataProfiles));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Register Redis Cache
            services.AddStackExchangeRedisCache(option =>
            {
                string conn = Configuration["Cache:RedisCache:Configuration"].ToString();
                option.ConfigurationOptions = ConfigurationOptions.Parse(conn);
                //option.ConfigurationOptions.AsyncTimeout = 2000;
                //option.ConfigurationOptions.ConnectTimeout = 2000;
                option.ConfigurationOptions.ConnectRetry = 1;
                option.InstanceName = Configuration["Cache:RedisCache:InstanceName"];
            });


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My NewsFood", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MyIdentityDataInitializer myIdentityData)
        {
            //var options = new RewriteOptions().AddRedirectToHttps(301, 44334);
            //app.UseRewriter(options);

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHsts();
            //app.UseHttpsRedirection();
           
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
                c.DisplayRequestDuration();
                c.DisplayOperationId();
            });
            app.UseMvc(routes =>
            {
                // SwaggerGen won't find controllers that are routed via this technique.
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            myIdentityData.SeedAdminUser();
            myIdentityData.SeedCategories();
            app.UseMvc();

        }

    }
}
