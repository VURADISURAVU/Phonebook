using System;

namespace Phonebook.BLL.DTO
{
	public class PhoneBookEntryDTO
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public DateTime Birthday { get; set; }
	}
}