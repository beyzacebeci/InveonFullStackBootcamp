using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class BeforeSRP
    {
        public class UserManager
        {
            public void RegisterUser(string username, string password)
            {
                Console.WriteLine($"User {username} registered");

                if (password.Length < 6)
                {
                    throw new Exception("password must be at least 6 characters long");
                }

                SaveToFile(username);
            }

            private void SaveToFile(string username)
            {
                Console.WriteLine($"user {username} saved to file");
            }
        }
    }
}
