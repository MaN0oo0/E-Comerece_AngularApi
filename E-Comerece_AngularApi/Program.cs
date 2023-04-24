
using Core.Interfaces;
using E_Comerece_AngularApi.Middelware;
using Infrerastructure.Data;
using Infrerastructure.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IProduct, ProductRepo>();
builder.Services.AddScoped(typeof(IGenricRepo<>),typeof(GenricRepo<>));


//Add Auto Mapper Configrations
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Handel Middelware Exception
app.UseMiddleware<ExceptionMiddelware>();

//Handel Errors call
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

#region Migration
using var scope = app.Services.CreateScope();
var Services = scope.ServiceProvider;
var context=Services.GetRequiredService<StoreContext>();
var Logger = Services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
    Logger.LogError(ex, "Error When Migration ");

}




#endregion






app.Run();
