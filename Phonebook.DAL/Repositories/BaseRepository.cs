using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phonebook.DAL.DataContext;
using Phonebook.DAL.Entities;
using Phonebook.DAL.Repositories.Interfaces;

namespace Phonebook.DAL.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
	{
		private readonly DatabaseContext _context;
		private readonly DbSet<TEntity> _dbSet;

		protected BaseRepository(DatabaseContext context)
		{
			_context = context;
			_dbSet = context.Set<TEntity>();
		}
		
		public void Save(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			_context.SaveChanges();
		}

		public TEntity GetById(long id)
		{
			return _context.Set<TEntity>().SingleOrDefault(x => x.Id == id);
		}

		public List<TEntity> GetAll()
		{
			return _context.Set<TEntity>().ToList();
		}

		public void Update(TEntity entity)
		{
			if (entity.Id > 0)
			{
				_context.Entry(entity).State = EntityState.Modified;
			}
			else
			{
				_dbSet.Add(entity);
			}
			
			_context.SaveChanges();
		}

		public void Remove(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
			_context.SaveChanges();
		}
	}
}