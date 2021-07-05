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
	public class ListaController : ControllerBase
	{
		private readonly IListaRepository _listaRepository;

		public ListaController(IListaRepository listaRepository)
		{
			_listaRepository = listaRepository;
		}

		/// <summary>
		/// Buscar listas por categoria utilizando o id da categoria.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("PorCategoria/{id}")]
		[Authorize]
		public async Task<ActionResult> BuscarListaPorCategoriaAsync(int id)
		{
			try
			{
				return Ok(await _listaRepository.BuscarListaPorCategoriaAsync(id));
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar categorias.");
			}
		}


		/// <summary>
		/// Buscar listas por nome.
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("{nome}")]
		[Authorize]
		public async Task<ActionResult> BuscarListaPorNomeAsync(string nome)
		{
			try
			{
				return Ok(await _listaRepository.BuscarListaPorNomeAsync(nome));
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar categorias.");
			}
		}


		/// <summary>
		/// Criar uma lista de tarefas.
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		[HttpPost]
		[Authorize]
		public async Task<ActionResult> CriarLista(Lista lista)
		{
			try
			{
				_listaRepository.CriarLista(lista);
				return Ok("Lista criada com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao criar uma lista.");
			}
		}


		/// <summary>
		/// Alterar umalista de tarefas.
		/// </summary>
		/// <param name="lista"></param>
		/// <returns></returns>
		[HttpPatch]
		[Authorize]
		public async Task<ActionResult> AlterarLista(Lista lista)
		{
			try
			{
				_listaRepository.AlterarLista(lista);
				return Ok("Lista alterada com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao alterar uma lista.");
			}
		}

		/// <summary>
		/// Excluir uma lista de tarefas.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult> RemoverLista(int id)
		{
			try
			{
				_listaRepository.RemoverLista(id);
				return Ok("Lista removida com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao remover uma lista.");
			}
		}
	}
}
