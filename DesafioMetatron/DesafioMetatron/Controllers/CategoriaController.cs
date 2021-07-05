using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DesafioMetatron.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriaController : ControllerBase
	{
		private readonly ICategoriaRepository _categoriaRepository;
		public CategoriaController(ICategoriaRepository categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}

		/// <summary>
		/// Buscar todas as categorias
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Authorize]
		public async Task<ActionResult> BuscarCategorias()
		{
			try
			{
				return Ok(await _categoriaRepository.BuscarTodasCategoriasAsync());
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar categorias.");
			}

		}

		/// <summary>
		/// Buscar categoria por Id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{Id}")]
		[Authorize]
		public async Task<ActionResult> BuscarCategoriasPorId(int Id)
		{
			try
			{
				return Ok(await _categoriaRepository.BuscarCategoriaPorIdAsync(Id));
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar categorias.");
			}

		}

		/// <summary>
		/// Criar uma categoria.
		/// </summary>
		/// <param name="categoria"></param>
		/// <returns></returns>
		[HttpPost]
		[Authorize]
		public async Task<ActionResult> CriarCategorias(Categoria categoria)
		{
			try
			{
				_categoriaRepository.CriarCategoria(categoria);
				return Ok("Categoria criada com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao criar uma categoria.");
			}

		}
	}
}
