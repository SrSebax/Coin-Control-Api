using Microsoft.AspNetCore.Mvc;
using CoinControl.Api.Models;
using CoinControl.Api.Services;
using System.Collections.Generic;

namespace CoinControl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            var categorias = _categoriaService.GetCategorias();
            return Ok(categorias);
        }
    }
}
