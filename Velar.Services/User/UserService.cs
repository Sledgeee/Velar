using System.Linq;
using Velar.Infrastructure.Repositories;

namespace Velar.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Infrastructure.Models.UserModel.User> _userRepository;

        public UserService(IRepository<Infrastructure.Models.UserModel.User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Infrastructure.Models.UserModel.User FindByEmail(string email)
        {
            var dbSet = _userRepository.GetDbSet();
            var user = dbSet.Where(x => x.Email == email)?.FirstOrDefault();
            return user;
        }
    }
}