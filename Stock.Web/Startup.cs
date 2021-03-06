using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stock.Web.EmailServices;
using StockWeb.Business.Abstract;
using StockWeb.Business.Concreate;
using StockWeb.Data.Abstract;
using StockWeb.Data.Concreate.EFCore;
using StockWeb.Data.Entity;
using StockWeb.Data.Identity;
using System;

namespace Stock.Web
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
            services.AddDbContext<APPDBContext>();
            services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<APPDBContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<CustomResetPassTokenProvider<Users>>("CustomResetPass")
                .AddTokenProvider<CustomConfirmEmailTokenProvider<Users>>("CustomConfirmEmail");


            services.AddCors(options =>
            {
                options.AddPolicy(name: "AnyToAll",
                    builder =>
                    {
                        builder.AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowAnyOrigin();

                    });
            });
            services.Configure<CustomResetPassTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(2));

            services.Configure<CustomConfirmEmailTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromDays(3));


            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout                
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.AllowedForNewUsers = true;

                // options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Tokens.PasswordResetTokenProvider = "CustomResetPass";
                options.Tokens.EmailConfirmationTokenProvider = "CustomConfirmEmail";
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".StockWeb.UserCookie"
                };


            });

            services.AddScoped<IProductRepository, EFCoreProductRepository>();
            services.AddScoped<ICategoryRepository, EFCoreCategoryRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IEmailSender, SMTPEmailSender>(i =>
                new SMTPEmailSender(
                    Configuration["EmailSender:Host"],
                    Configuration.GetValue<int>("EmailSender:Port"),
                    Configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    Configuration["EmailSender:Username"],
                    Configuration["EmailSender:Password"])
            );

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");











            });
        }
    }
}
