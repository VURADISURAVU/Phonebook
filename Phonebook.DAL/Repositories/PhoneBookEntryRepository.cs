using System.Linq;
using Phonebook.DAL.DataContext;
using Phonebook.DAL.Entities;
using Phonebook.DAL.Repositories.Interfaces;

namespace Phonebook.DAL.Repositories
{
	public class PhoneBookEntryRepository : BaseRepository<PhoneBookEntry>, IPhoneBookEntryRepository
	{
		private readonly DatabaseContext _context;
		public PhoneBookEntryRepository(DatabaseContext context) : base(context)
		{
			_context = context;
		}

		public void RemoveById(long id)
		{
			var entry = _context.PhoneBookEntries.SingleOrDefault(x => x.Id == id);
			_context.Remove(entry);
			_context.SaveChanges();
		}
	}
}