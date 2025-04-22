using CoinControl.Api.Services;
using CoinControl.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Firebase
builder.Services.AddSingleton<FirebaseService>();

// DbContext
builder.Services.AddDbContext<CoinControlDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servicios
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();

// CORS Configuration: Permite solicitudes desde tu frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // URL de tu frontend React
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// MVC
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configurar middleware para CORS
app.UseCors("AllowLocalhost"); // Usa la política de CORS que configuramos antes

app.UseHttpsRedirection();
app.UseAuthorization();
;

app.Run();
