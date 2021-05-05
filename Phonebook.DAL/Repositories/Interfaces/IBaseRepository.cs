using System.Collections.Generic;
using Phonebook.DAL.Entities;

namespace Phonebook.DAL.Repositories.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : BaseModel
	{
		public void Save(TEntity entity);
		public TEntity GetById(long id);
		public List<TEntity> GetAll();
		public void Update(TEntity entity);
		public void Remove(TEntity entity);
	}
}