using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System;
using System.Net.Mail;

namespace APIServer.Helper
{
	public class Utils
	{
		public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
		public static bool isValidPhoneNumber(string phoneNumber)
		{
			if (phoneNumber != null) return Regex.IsMatch(phoneNumber, motif);
			else return false;
		}

		public static bool isValidEmail(string email)
		{
			var valid = true;

			try
			{
				var emailAddress = new MailAddress(email);
			}
			catch
			{
				valid = false;
			}

			return valid;
		}
	}
}
