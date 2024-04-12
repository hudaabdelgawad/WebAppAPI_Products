using Microsoft.EntityFrameworkCore;
using WebApp_Products.Data;
using WebApp_Products.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
   
option.UseSqlServer(builder.Configuration.GetConnectionString("ProductConnection")));
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", buil =>
{
    buil.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();

}));
builder.Services.AddTransient<ICategoriesSevices, CategoriesSevices>();
builder.Services.AddTransient<IProductsSevices, ProductsSevices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
