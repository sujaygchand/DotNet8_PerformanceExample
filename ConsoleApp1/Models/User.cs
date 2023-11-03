using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1.Models
{
	public class User : ISpanParsable<User>
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool HasAccount { get; set; }
		public int Age { get; set; }

		public User(int Id, string FirstName, string LastName, bool HasAccount, int Age)
		{
			this.Id = Id;
			this.FirstName = FirstName;
			this.LastName = LastName;
			this.HasAccount = HasAccount;
			this.Age = Age;
		}

		public override string ToString()
		{
			return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, HasAccount: {HasAccount}, Age: {Age}";
		}
		public static User Parse(string s, IFormatProvider? provider = null)
		{
			var splitTest = s.Split(',');
			var id = int.Parse(splitTest[0]);
			var firstName = splitTest[1];
			var lastName = splitTest[2];
			var hasAccount = bool.Parse(splitTest[3]);
			var age = int.Parse(splitTest[4]);

			return new User(id, firstName, lastName, hasAccount, age);
		}

		public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out User result)
		{
			try
			{
				var splitTest = s.Split(',');
				var id = int.Parse(splitTest[0]);
				var firstName = splitTest[1];
				var lastName = splitTest[2];
				var hasAccount = bool.Parse(splitTest[3]);
				var age = int.Parse(splitTest[4]);

				result = new User(id, firstName, lastName, hasAccount, age);
			}

			catch(Exception)
			{
				result = null;
				return false;
			}

			return true;
		}

		public static User Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null)
		{

				Span<Range> dest = stackalloc Range[5];
				s.Split(dest, ',');
				var id = int.Parse(s[dest[0]]);
				var firstName = s[dest[1]].ToString();
				var lastName = s[dest[2]].ToString();
				var hasAccount = bool.Parse(s[dest[3]]);
				var age = int.Parse(s[dest[4]]);

			   return new User(id, firstName, lastName, hasAccount, age);

		}

		public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out User result)
		{
			try
			{
				Span<Range> dest = stackalloc Range[5];
				s.Split(dest, ',');
				var id = int.Parse(s[dest[0]]);
				var firstName = s[dest[1]].ToString();
				var lastName = s[dest[2]].ToString();
				var hasAccount = bool.Parse(s[dest[3]]);
				var age = int.Parse(s[dest[4]]);

				result = new User(id, firstName, lastName, hasAccount, age);
			}

			catch (Exception)
			{
				result = null;
				return false;
			}

			return true;
		}
	}
}
