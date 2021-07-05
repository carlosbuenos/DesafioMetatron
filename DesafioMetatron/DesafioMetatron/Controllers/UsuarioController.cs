using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Builders.Interfaces;
using DesafionMetatron.Domain.Repositories.Interfaces;
using DesafionMetatron.Domain.Util;
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
	public class UsuarioController : ControllerBase
	{
		private readonly IRegrasParaValidacaoDeSenha _regrasParaValidacaoDeSenha;
		private readonly IUsuarioRepository _usuarioRepository;
		public UsuarioController(IUsuarioRepository usuarioRepository,
			IRegrasParaValidacaoDeSenha regrasParaValidacaoDeSenha)
		{
			_usuarioRepository = usuarioRepository;
			_regrasParaValidacaoDeSenha = regrasParaValidacaoDeSenha;
		}

		/// <summary>
		/// Permite buscar todos os usuarios
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ActionResult> BuscarTodosUsuarios()
		{
			try
			{
				return Ok(await _usuarioRepository.BuscarTodosUsuariosAsync());
			}
			catch (Exception)
			{

				return BadRequest("falha ao consultar todos os usuários.");
			}

		}


		/// <summary>
		/// permite gerar um token para um usuario existente.
		/// </summary>
		/// <param name="login"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Token")]
		public async Task<ActionResult> GerarToken(Login login)
		{
			try
			{
				if (!(await _usuarioRepository.ValidarUsuarioPorEmaieSenhaAsync(login.Email, Criptografia.CriptografarValor(login.Senha))))
				{
					BadRequest("Usuario não encontrado.");
				}

				var _token = Token.GenerateToken(login);

				return Ok(new
				{
					email = login.Email,
					token = _token
				});
			}
			catch (Exception)
			{

				return BadRequest("falha ao consultar todos os usuários.");
			}

		}

		/// <summary>
		/// Metodo utilizado para salvar usuarios.
		/// 
		/// regras para Senha
		/// Nove ou mais caracteres
		/// Ao menos 1 dígito
		/// Ao menos 1 letra minúscula
		/// Ao menos 1 letra maiúscula
		/// Ao menos 1 caractere especial - Considerando como especial os seguintes caracteres: !@#$%^&*()-+
		/// Não possuir caracteres repetidos dentro do conjunto
		/// 
		/// regras para formato de email
		/// Ex: teste@teste.com
		/// </summary>
		/// <param name="usuario"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> CriarUsuario(Usuario usuario)
		{
			try
			{
				if (!usuario.EUmEmailValido())
				{
					return BadRequest("email não corresponde aos padões necessários.");
				}

				if (!usuario.SenhaValida(_regrasParaValidacaoDeSenha))
				{
					return BadRequest("A senha não atende aos requisitos");
				}


				_usuarioRepository.CriarUsuarioAsync(usuario);
				return Ok("Usuário salvo com sucesso.");
			}
			catch (Exception)
			{

				return BadRequest("Falha ao salvar usuario");
			}
		}
	}
}
