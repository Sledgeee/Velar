using System.Threading.Tasks;

namespace Velar.Services.User
{
    public interface IUserService
    {
        Infrastructure.Models.UserModel.User FindByEmail(string email);
    }
}