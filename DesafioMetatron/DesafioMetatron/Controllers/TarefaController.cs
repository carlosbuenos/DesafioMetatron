using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMetatron.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TarefaController : ControllerBase
	{
		private readonly ITarefaRepository _tarefaRepository;
		public TarefaController(ITarefaRepository tarefaRepository)
		{
			_tarefaRepository = tarefaRepository;
		}

		/// <summary>
		/// Permite buscar todas as tarefas relacionadas a uma lista especifica
		/// sem retornar o objeto lista junto.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("PorLista/{id}")]
		[Authorize]
		public async Task<ActionResult> BuscarTarefaPorListaAsync(int id)
		{
			try
			{
				return Ok(await _tarefaRepository.BuscarTarefaPorListaAsync(id));
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar tarefa.");
			}
		}

		/// <summary>
		/// Permite buscar todas as tarefas atribuidas a um usuariuo especifico
		/// sem retornar o objeto lista junto.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("PorUsuario/{id}")]
		[Authorize]
		public async Task<ActionResult> BuscarTarefaPorUsuarioAsync(int id)
		{
			try
			{
				return Ok(await _tarefaRepository.BuscarTarefaPorUsuarioAsync(id));
			}
			catch (Exception)
			{

				return BadRequest("Falha ao consultar tarefa.");
			}
		}
		
		/// <summary>
		/// Permite criar uma tarefa
		/// </summary>
		/// <param name="tarefa"></param>
		/// <returns></returns>
		[HttpPost]
		[Authorize]
		public async Task<ActionResult> CriarTarefa(Tarefa tarefa)
		{
			try
			{
				_tarefaRepository.CriarTarefa(tarefa);
				return Ok("Tarefa criada com sucesso.");
			}
			catch (Exception ex)
			{

				return BadRequest("Falha ao criar uma tarefa.");
			}
		}

		/// <summary>
		/// Permite alterar uma tarefa
		/// </summary>
		/// <param name="tarefa"></param>
		/// <returns></returns>
		[HttpPatch]
		[Authorize]
		public async Task<ActionResult> AlterarTarefa(Tarefa tarefa)
		{
			try
			{
				_tarefaRepository.AlterarTarefa(tarefa);
				return Ok("Tarefa alterada com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao alterar uma tarefa.");
			}
		}

		/// <summary>
		/// Permite excluir uma tarefa
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("{id}")]
		[Authorize]
		public async Task<ActionResult> RemoverTarefa(int id)
		{
			try
			{
				_tarefaRepository.RemoverTarefa(id);
				return Ok("Tarefa removida com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao remover uma tarefa.");
			}
		}
	}
}
