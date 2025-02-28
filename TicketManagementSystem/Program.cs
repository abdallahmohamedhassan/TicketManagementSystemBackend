using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Infrastructure.Persistence;
using TicketManagementSystem.Application.Handlers;

using MediatR;
using TicketManagementSystem.Infrastructure.Repositories;
using Sentry.Profiling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://30e780b4e7b3040238632aba8a29a432@o4507820608520192.ingest.us.sentry.io/4507820610093056";

    // Enable debugging to see SDK logs
    o.Debug = true;

    // Capture 100% of transactions for tracing
    o.TracesSampleRate = 1.0;

    // Capture 100% of transactions for profiling (adjust in production)
    o.ProfilesSampleRate = 1.0;

    // Add the Profiling Integration
    o.AddIntegration(new ProfilingIntegration(
        // Synchronous profiling startup with a 500ms timeout (optional)
        TimeSpan.FromMilliseconds(500)
    ));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(CreateTicketHandler).Assembly);
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()   
                  .AllowAnyMethod()   
                  .AllowAnyHeader();  
        });
});
var app = builder.Build();
app.UseSentryTracing();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
