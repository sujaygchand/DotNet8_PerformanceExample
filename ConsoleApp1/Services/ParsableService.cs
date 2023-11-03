using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
	public class ParsableService
	{
        private string UserJsonData = "3,Joe,Joestar,true,20";


        public User GetUser()
        {
            return User.Parse(UserJsonData);
        }

        public User TryGetUser()
        {
            var isValid = User.TryParse(UserJsonData, null, out User user);

            return isValid ? user : null;
        }

        public User GetUserAsSpan()
        {
            return User.Parse(UserJsonData.AsSpan());
        }

        public User TryGetUserAsSpan()
        {
            var isValid = User.TryParse(UserJsonData.AsSpan(), null, out User user);

            return isValid ? user : null;
        }
    }
}
