using Hope.Core;

namespace Hope.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public User GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
