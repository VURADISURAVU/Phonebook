using System;

namespace Phonebook.DAL.Entities
{
	public class PhoneBookEntry : BaseModel
	{
		public string Name { get; set; }
		public string SecondName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public DateTime Birthday { get; set; }
	}
}