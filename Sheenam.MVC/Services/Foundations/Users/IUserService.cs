using Sheenam.MVC.Models.Users;

namespace Sheenam.MVC.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
    }
}
