using System.Collections.Generic;
using Phonebook.BLL.DTO;
using Phonebook.DAL.Entities;

namespace Phonebook.BLL.Interfaces
{
	public interface IPhoneBookEntryService
	{
		public void Create(PhoneBookEntryDTO entryDto);
		public PhoneBookEntryDTO GetById(long id);
		public List<PhoneBookEntry> GetAll();
		public void Update(PhoneBookEntryDTO entryDto);
		public void Remove(PhoneBookEntryDTO entryDto);
		public void RemoveEntry(long id);
	}
}