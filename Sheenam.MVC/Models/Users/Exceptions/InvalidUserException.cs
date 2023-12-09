using Xeptions;

namespace Sheenam.MVC.Models.Users.Exceptions
{
    public class InvalidUserException : Xeption
    {
        public InvalidUserException()
            :base("User is invalid")
        { }

    }
}
