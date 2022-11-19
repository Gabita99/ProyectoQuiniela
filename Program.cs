using Microsoft.EntityFrameworkCore;
using ProyectoQuiniela.Context;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QuinielaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Cadena"));
});

//Serializacion de los controladores con Json 
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(//c =>
    //{
       // c.RoutePrefix = String.Empty;
    //}
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
