using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafionMetatron.Domain.Repositories.Interfaces
{
	public interface IUsuarioRepository
	{
		Task CriarUsuarioAsync(Usuario usuario);
		Task<IList<Usuario>> BuscarTodosUsuariosAsync();
		Task<bool> ValidarUsuarioPorEmaieSenhaAsync(string email, string senha);
	}
}
