using DesafioMetatron.Infra.DataBase;
using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMetatron.Infra.Repositories.ConcreteObjects
{
	public class UsuarioRepository : IUsuarioRepository
	{
		MetatronContext _dbContext;
		public UsuarioRepository(MetatronContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IList<Usuario>> BuscarTodosUsuariosAsync()
		{
			return await Task.FromResult(_dbContext.Usuario.ToList());
		}

		public async Task<bool> ValidarUsuarioPorEmaieSenhaAsync(string email, string senha)
		{
			var resultado = await _dbContext.Usuario
				.Where(w => w.Email == email && w.Senha == senha)
				.FirstOrDefaultAsync();

			if (resultado!= null && resultado.Email == email)
			{
				return true;
			}
			return false;
		}

		public async Task CriarUsuarioAsync(Usuario usuario)
		{
			try
			{
				usuario.CriptografarSenha();
				_dbContext.Usuario.Add(usuario);
				_dbContext.SaveChanges();
			}
			catch (System.Exception ex)
			{

				throw ex;
			}

		}

	}
}
