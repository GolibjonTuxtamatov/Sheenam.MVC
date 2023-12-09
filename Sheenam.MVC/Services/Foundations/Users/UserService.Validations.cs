using Sheenam.MVC.Models.Users;
using Sheenam.MVC.Models.Users.Exceptions;
using Xeptions;

namespace Sheenam.MVC.Services.Foundations.Users
{
    public partial class UserService
    {
        private void ValidateUserNotNull(User user)
        {
            if (user == null)
                throw new NullUserException();
        }
    }
}
