using Phonebook.DAL.Entities;

namespace Phonebook.DAL.Repositories.Interfaces
{
	public interface IPhoneBookEntryRepository : IBaseRepository<PhoneBookEntry>
	{
		public void RemoveById(long id);
	}
}