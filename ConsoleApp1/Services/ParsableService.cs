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
            User.TryParse(UserJsonData, null, out User user);

            return user;
        }

        public User GetUserAsSpan()
        {
            return User.Parse(UserJsonData.AsSpan());
        }

        public User TryGetUserAsSpan()
        {
            User.TryParse(UserJsonData.AsSpan(), null, out User user);

            return user;
        }
    }
}
