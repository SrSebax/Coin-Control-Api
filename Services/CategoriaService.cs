using CoinControl.Api.Models;
using CoinControl.Api.Data; // Asegúrate de importar tu contexto
using System.Collections.Generic;
using System.Linq;

namespace CoinControl.Api.Services
{
    public class CategoriaService
    {
        private readonly CoinControlDbContext _context;

        public CategoriaService(CoinControlDbContext context)
        {
            _context = context;
        }

        public List<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

    }
}
