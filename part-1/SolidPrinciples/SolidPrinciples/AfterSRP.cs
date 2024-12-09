using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    public class AfterSRP
    {
        public class UserManager
        {
            private readonly IPasswordValidator _passwordValidator;
            private readonly IUserRepository _userRepository;

            public UserManager(IPasswordValidator passwordValidator, IUserRepository userRepository)
            {
                _passwordValidator = passwordValidator;
                _userRepository = userRepository;
            }

            public void RegisterUser(string username, string password)
            {
                if (!_passwordValidator.Validate(password))
                {
                    throw new Exception("password must be at least 6 characters longg");
                }

                _userRepository.SaveUser(username);
                Console.WriteLine($"User {username} registered.");
            }
        }
        public interface IPasswordValidator
        {
            bool Validate(string password);
        }

        public class PasswordValidator : IPasswordValidator
        {
            public bool Validate(string password)
            {
                return password.Length >= 6;
            }
        }

        public interface IUserRepository
        {
            void SaveUser(string username);
        }

        public class FileUserRepository : IUserRepository
        {
            public void SaveUser(string username)
            {
                Console.WriteLine($"user {username} saved to file.");
            }
        }
    }
}
