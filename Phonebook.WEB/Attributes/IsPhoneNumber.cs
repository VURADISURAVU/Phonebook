using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Phonebook.WEB.Attributes
{
	public class IsPhoneNumber : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			const string regex = @"^((\+7|7|8)+([0-9]){10})$";
			var str = value as string;

			if (string.IsNullOrEmpty(str))
			{
				return false;
			}

			var match = Regex.Match(str, regex);
			
			return match.Success;
		}
	}
}