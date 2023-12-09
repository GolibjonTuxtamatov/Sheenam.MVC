using Xeptions;

namespace Sheenam.MVC.Models.Users.Exceptions
{
    public class UserValidationException : Xeption
    {
        public UserValidationException(Xeption innerException)
            : base("User validation error occured, fix the error and try again",
                 innerException)
        { }
    }
}
