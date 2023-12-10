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
            ValueTask<User> addUserTask =
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

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionIfUserIsInvalidAndLogItAsync(string text)
        {
            //given
            User invalidUser = new User
            {
                FirstName = text,
            };

            var invalidUserException = new InvalidUserException();

            invalidUserException.AddData(
                key: nameof(User.Id),
                values: "Id is required");

            invalidUserException.AddData(
                key: nameof(User.FirstName),
                values: "Text is required");

            invalidUserException.AddData(
                key: nameof(User.LastName),
                values: "Text is required");

            invalidUserException.AddData(
                key: nameof(User.DateOfBirth),
                values: "Date is required");

            invalidUserException.AddData(
                key: nameof(User.Email),
                values: "Text is required");

            invalidUserException.AddData(
                key: nameof(User.Password),
                values: "Text is required");

            var expectedUserValidationException = new UserValidationException(invalidUserException);

            //when
            ValueTask<User> addUserTask = this.userService.AddUserAsync(invalidUser);

            UserValidationException userValidationException =
                await Assert.ThrowsAsync<UserValidationException>(addUserTask.AsTask);

            userValidationException.Should().BeEquivalentTo(expectedUserValidationException);

            //then
            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SamExceptionAs(expectedUserValidationException))),
                Times.Once());

            this.storageBrokerMock.Verify(broker =>
                broker.InsertUserAsync(It.IsAny<User>()),
                Times.Never());

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
