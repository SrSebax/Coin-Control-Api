using Microsoft.EntityFrameworkCore;
using CoinControl.Api.Models;

namespace CoinControl.Api.Data.Seed
{
    public static class CategoriaSeed
    {
        public static void SeedCategorias(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Hogar", Tipo = "Gasto", Icono = "Home", Color = "#4CAF50" },
                new Categoria { Id = 2, Nombre = "Compras", Tipo = "Gasto", Icono = "ShoppingCart", Color = "#FF9800" },
                new Categoria { Id = 3, Nombre = "Salud", Tipo = "Gasto", Icono = "LocalHospital", Color = "#F44336" },
                new Categoria { Id = 4, Nombre = "Comida", Tipo = "Gasto", Icono = "LocalDining", Color = "#2196F3" },
                new Categoria { Id = 5, Nombre = "Transporte", Tipo = "Gasto", Icono = "DirectionsCar", Color = "#607D8B" },
                new Categoria { Id = 6, Nombre = "Viajes", Tipo = "Gasto", Icono = "Flight", Color = "#00BCD4" },
                new Categoria { Id = 7, Nombre = "Música", Tipo = "Gasto", Icono = "MusicNote", Color = "#9C27B0" },
                new Categoria { Id = 8, Nombre = "Mascotas", Tipo = "Gasto", Icono = "Pets", Color = "#8D6E63" },
                new Categoria { Id = 9, Nombre = "Gasolina", Tipo = "Gasto", Icono = "LocalGasStation", Color = "#FF5722" },
                new Categoria { Id = 10, Nombre = "Salario", Tipo = "Ingreso", Icono = "AttachMoney", Color = "#009688" },
                new Categoria { Id = 11, Nombre = "Trabajo", Tipo = "Ingreso", Icono = "Work", Color = "#3F51B5" },
                new Categoria { Id = 12, Nombre = "Bonos", Tipo = "Ingreso", Icono = "CardGiftcard", Color = "#E91E63" },
                new Categoria { Id = 13, Nombre = "Ventas", Tipo = "Ingreso", Icono = "Storefront", Color = "#673AB7" },
                new Categoria { Id = 14, Nombre = "Ahorro", Tipo = "Ahorro", Icono = "Savings", Color = "#CDDC39" },
                new Categoria { Id = 15, Nombre = "Meta", Tipo = "Ahorro", Icono = "EmojiEvents", Color = "#FFC107" },
                new Categoria { Id = 16, Nombre = "Acciones", Tipo = "Inversion", Icono = "TrendingUp", Color = "#00C853" },
                new Categoria { Id = 17, Nombre = "Educación", Tipo = "Inversion", Icono = "School", Color = "#3E2723" },
                new Categoria { Id = 18, Nombre = "Bienestar", Tipo = "Inversion", Icono = "Spa", Color = "#AED581" }
            );
        }
    }
}
