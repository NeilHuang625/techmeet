using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Repositories;

namespace techmeet.App_start{
    public class Startup{

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services){
            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{
                endpoints.MapControllers();
            });
        }
    }
}