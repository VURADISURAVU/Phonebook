using System.Collections.Generic;
using Phonebook.BLL.DTO;
using Phonebook.BLL.Interfaces;
using Phonebook.DAL.Entities;
using Phonebook.DAL.Repositories;
using Phonebook.DAL.Repositories.Interfaces;

namespace Phonebook.BLL.Services
{
	public class PhoneBookEntryService : IPhoneBookEntryService
	{
		private readonly IPhoneBookEntryRepository _repository;

		public PhoneBookEntryService(PhoneBookEntryRepository repository)
		{
			_repository = repository;
		}
		
		public void Create(PhoneBookEntryDTO entryDto)
		{
			var newEntry = new PhoneBookEntry()
			{
				Name = entryDto.Name,
				SecondName = entryDto.SecondName,
				Email = entryDto.Email,
				Gender = entryDto.Gender,
				Birthday = entryDto.Birthday,
				PhoneNumber = entryDto.PhoneNumber
			};
			
			_repository.Save(newEntry);
		}

		public PhoneBookEntryDTO GetById(long id)
		{
			var findEntry = _repository.GetById(id);

			var entry = new PhoneBookEntryDTO()
			{
				Id = findEntry.Id,
				Name = findEntry.Name,
				SecondName = findEntry.SecondName,
				Email = findEntry.Email,
				Gender = findEntry.Gender,
				Birthday = findEntry.Birthday,
				PhoneNumber = findEntry.PhoneNumber
			};

			return entry;
		}

		public List<PhoneBookEntry> GetAll()
		{
			return _repository.GetAll();
		}

		public void Update(PhoneBookEntryDTO entryDto)
		{
			var entry = new PhoneBookEntry()
			{
				Id = entryDto.Id,
				Name = entryDto.Name,
				SecondName = entryDto.SecondName,
				Email = entryDto.Email,
				Gender = entryDto.Gender,
				Birthday = entryDto.Birthday,
				PhoneNumber = entryDto.PhoneNumber
			};
			
			_repository.Update(entry);
		}

		public void Remove(PhoneBookEntryDTO entryDto)
		{
			var entry = new PhoneBookEntry()
			{
				Name = entryDto.Name,
				SecondName = entryDto.SecondName,
				Email = entryDto.Email,
				Gender = entryDto.Gender,
				Birthday = entryDto.Birthday,
				PhoneNumber = entryDto.PhoneNumber
			};
			
			_repository.Remove(entry);
		}

		public void RemoveEntry(long id)
		{
			_repository.RemoveById(id);
		}
	}
}