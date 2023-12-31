﻿using Sheenam.MVC.Models.Users;
using Sheenam.MVC.Models.Users.Exceptions;
using Xeptions;

namespace Sheenam.MVC.Services.Foundations.Users
{
    public partial class UserService
    {
        private delegate ValueTask<User> ReturningUserFunction();

        private async ValueTask<User> TryCatch(ReturningUserFunction returningUserFunction)
        {
            try
            {
                return await returningUserFunction();
            }
            catch (NullUserException nullException)
            {
                throw CreateAndLogValidationExcrption(nullException);
            }
            catch (InvalidUserException invalidUserException)
            {
                throw CreateAndLogValidationExcrption(invalidUserException);
            }
        }

        private UserValidationException CreateAndLogValidationExcrption(Xeption exception)
        {
            var userValidationException = new UserValidationException(exception);
            this.loggingBroker.LogError(userValidationException);

            return userValidationException;
        }
    }
}
