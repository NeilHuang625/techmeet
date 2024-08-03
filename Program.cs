using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DB Configuration
builder.Services.AddDbContext<EventContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register repositories
builder.Services.AddScoped<IEventRepository, EventRepository>();

// Allow CORS
builder.Services.AddCors( options => {
    options.AddDefaultPolicy(policy=>{
        policy.SetIsOriginAllowed(origin=> new Uri(origin).Host == "localhost")
            .AllowAnyHeader()
            .AllowAnyMethod(); // For localhost only.
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();