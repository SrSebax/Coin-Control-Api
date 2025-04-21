using CoinControl.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar FirebaseService al contenedor de servicios
builder.Services.AddSingleton<FirebaseService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
