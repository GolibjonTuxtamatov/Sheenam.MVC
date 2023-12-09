using Moq;
using Sheenam.MVC.Brokers.Loggings;
using Sheenam.MVC.Brokers.Storages;
using Sheenam.MVC.Models.Users;
using Sheenam.MVC.Services.Foundations.Users;
using Tynamix.ObjectFiller;

namespace Sheenam.MVC.Tests.Unit.Services.Foundations.Users
{
    public partial class UserServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly IUserService userService;

        public UserServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

            this.userService = new UserService(
                this.storageBrokerMock.Object,
                this.loggingBrokerMock.Object);
        }

        private User CreateRandomUser() =>
            CreateUserFiller(GetDateTimeOffset()).Create();

        private Filler<User> CreateUserFiller(DateTimeOffset date)
        {
            var filler = new Filler<User>();

            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }

        private DateTimeOffset GetDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
    }
}
