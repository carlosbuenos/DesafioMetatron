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
	public class ListaRepository : IListaRepository
	{
		MetatronContext _dbContext;
		public ListaRepository(MetatronContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<IList<Lista>> BuscarListaPorCategoriaAsync(int idCategoria)
		{
			return await _dbContext.Lista.Where(w => w.CategoriaId == idCategoria).ToListAsync();
		}

		public async Task<IList<Lista>> BuscarListaPorNomeAsync(string nome)
		{
			return await _dbContext.Lista.Where(w => w.Nome == nome).ToListAsync();
		}

		public void CriarLista(Lista lista)
		{
			_dbContext.Lista.Add(lista);
			_dbContext.SaveChanges();
		}

		public void AlterarLista(Lista lista)
		{
			try
			{
				_dbContext.Update(lista);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

		public void RemoverLista(int IdLista)
		{
			var listaRemovida = new Lista { Id = IdLista };
			_dbContext.Lista.Remove(listaRemovida);
			_dbContext.SaveChanges();
		}
	}
}
