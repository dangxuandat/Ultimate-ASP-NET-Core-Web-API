using Microsoft.EntityFrameworkCore;
using Serilog;
using Ultimate_ASP_NET_Core__Web__API.API.Configurations;
using Ultimate_ASP_NET_Core__Web__API.API.Contracts;
using Ultimate_ASP_NET_Core__Web__API.API.Data;
using Ultimate_ASP_NET_Core__Web__API.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<HotelListDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", 
		b => b.AllowAnyHeader()
										  .AllowAnyOrigin()
										  .AllowAnyMethod());
});

builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(ICountriesRepository), typeof(CountriesRepository));

var app = builder.Build();

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
