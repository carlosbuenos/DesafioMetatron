using DesafioMetatron.Infra.DataBase;
using DesafionMetatron.Domain;
using DesafionMetatron.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMetatron.Infra.Repositories.ConcreteObjects
{
	public class CategoriaRepository : ICategoriaRepository
	{

		MetatronContext _dbContext;
		public CategoriaRepository(MetatronContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Categoria> BuscarCategoriaPorIdAsync(int Id)
		{
			return await _dbContext.Categoria.Where(w => w.Id == Id).FirstOrDefaultAsync();
		}

		public async Task<IList<Categoria>> BuscarTodasCategoriasAsync()
		{
			return await _dbContext.Categoria.ToListAsync();
		}

		public void CriarCategoria(Categoria categoria)
		{
			try
			{
				_dbContext.Categoria.Add(categoria);
				_dbContext.SaveChanges();
			}
			catch (System.Exception ex)
			{

				throw ex;
			}
		}
	}
}
