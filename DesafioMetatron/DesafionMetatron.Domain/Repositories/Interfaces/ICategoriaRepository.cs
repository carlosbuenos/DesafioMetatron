using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafionMetatron.Domain.Repositories.Interfaces
{
	public interface ICategoriaRepository
	{
		void CriarCategoria(Categoria categoria);
		Task<IList<Categoria>> BuscarTodasCategoriasAsync();
		Task<Categoria> BuscarCategoriaPorIdAsync(int Id);
	}
}
