using DesafioMetatron.Infra.DataBase;
using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioMetatron.Infra.Repositories.ConcreteObjects
{
	public class TarefaRepository: ITarefaRepository
	{
		MetatronContext _dbContext;
		public TarefaRepository(MetatronContext dbContext)
		{
			_dbContext = dbContext;
		}
		
		public async Task<IList<Tarefa>> BuscarTarefaPorListaAsync(int idLista)
		{
			return await _dbContext.Tarefa.Where(w => w.ListaId == idLista).ToListAsync();
		}

		public async Task<IList<Tarefa>> BuscarTarefaPorUsuarioAsync(int idUsuario)
		{
			return await _dbContext.Tarefa.Where(w => w.UsuarioId == idUsuario).ToListAsync();
		}

		public void CriarTarefa(Tarefa tarefa)
		{
			_dbContext.Tarefa.Add(tarefa);
			_dbContext.SaveChanges();
		}

		public void AlterarTarefa(Tarefa tarefa)
		{
			_dbContext.Update(tarefa);
			_dbContext.SaveChanges();
		}

		public void RemoverTarefa(int IdTarefa)
		{
			var tarefaRemovida = new Tarefa { Id = IdTarefa };
			_dbContext.Tarefa.Remove(tarefaRemovida);
			_dbContext.SaveChanges();
		}
	}
}
