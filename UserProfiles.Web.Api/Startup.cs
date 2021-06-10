using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserProfiles.Domain.Common.Data;
using UserProfiles.Domain.Common.Data.DataContext;
using UserProfiles.Domain.Common.Initializers;
using UserProfiles.Domain.Data;
using UserProfiles.Domain.UserProfiles.Data;
using UserProfiles.Domain.UserProfiles.Services;
using UserProfiles.Web.Api.Middleware;

namespace UserProfiles.Web.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserProfileDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddIdentity<User, Role>(opts =>
            {
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = true;
                opts.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<UserProfileDataContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<UnitOfWork<UserProfileDataContext>>();

            // Initializers
            services.AddScoped<IDatabaseInitializer, ProfileDatabaseInitializer>();

            services.AddTransient<IUserProfileService, UserProfileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
        }
    }
}
