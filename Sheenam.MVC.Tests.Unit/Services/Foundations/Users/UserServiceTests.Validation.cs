using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Sheenam.MVC.Models.Users;
using Sheenam.MVC.Models.Users.Exceptions;
using Xunit;

namespace Sheenam.MVC.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionIfUserIsNullAndLogItAsync()
        {
            //given
            User nullUser = null;
            var nullUserException = new NullUserException();

            var expectedUserValidationException =
                new UserValidationException(nullUserException);

            //when
            ValueTask<User> addUserTask  =
                this.userService.AddUserAsync(nullUser);

            UserValidationException userValidationException = 
                await Assert.ThrowsAsync<UserValidationException>(() =>
                    addUserTask.AsTask());

            userValidationException.Should().BeEquivalentTo(expectedUserValidationException);

            //then
            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SamExceptionAs(expectedUserValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertUserAsync(nullUser),
                Times.Never());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
