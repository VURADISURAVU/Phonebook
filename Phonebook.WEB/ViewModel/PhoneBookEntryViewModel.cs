using System.ComponentModel.DataAnnotations;
using Phonebook.WEB.Attributes;

namespace Phonebook.WEB.ViewModel
{
	public class PhoneBookEntryViewModel
	{
		public long Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string SecondName { get; set; }
		[Required]
		[IsEmail(ErrorMessage = "Введите корректный адрес почты")]
		public string Email { get; set; }
		[Required]
		[IsPhoneNumber(ErrorMessage = "Введите корректный номер телефона")]
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public string Birthday { get; set; }
	}
}