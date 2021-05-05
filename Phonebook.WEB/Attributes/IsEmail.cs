using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Phonebook.WEB.Attributes
{
	public class IsEmail : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var str = value as string;

			if (string.IsNullOrEmpty(str))
			{
				return false;
			}
			
			try
			{
				var m = new MailAddress(str);

				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
	}
}