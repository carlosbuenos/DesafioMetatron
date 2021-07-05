using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafionMetatron.Domain.Repositories.Interfaces
{
	public interface IListaRepository
	{
		Task<IList<Lista>> BuscarListaPorNomeAsync(string nome);
		Task<IList<Lista>> BuscarListaPorCategoriaAsync(int idCategoria);

		void CriarLista(Lista lista);
		void AlterarLista(Lista lista);
		void RemoverLista(int IdLista);

	}
}
