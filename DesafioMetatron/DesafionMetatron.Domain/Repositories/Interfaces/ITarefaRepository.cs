using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafionMetatron.Domain.Repositories.Interfaces
{
	public interface ITarefaRepository
	{
		Task<IList<Tarefa>> BuscarTarefaPorListaAsync(int idLista);
		Task<IList<Tarefa>> BuscarTarefaPorUsuarioAsync(int idUsuario);

		void CriarTarefa(Tarefa tarefa);
		void AlterarTarefa(Tarefa tarefa);
		void RemoverTarefa(int IdTarefa);
	}
}
