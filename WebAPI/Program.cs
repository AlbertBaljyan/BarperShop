using BLL.Services;
using DAL;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<BarberShopDB>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("BarberShopConnectionStrings")));


        builder.Services.AddScoped<IBarberService, BarberService>();
        builder.Services.AddScoped<IBarberScheduleService, BarberScheduleService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();

        builder.Services.AddScoped<IBarberRepository, BarberRepository>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<IBarberScheduleRepository, BarberScheduleRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAll");


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}