using Xeptions;

namespace Sheenam.MVC.Models.Users.Exceptions
{
    public class NullUserException : Xeption
    {
        public NullUserException()
            : base("User is null")
        { }
    }
}
