﻿using Sheenam.MVC.Brokers.Loggings;
using Sheenam.MVC.Brokers.Storages;
using Sheenam.MVC.Models.Users;

namespace Sheenam.MVC.Services.Foundations.Users
{
    public partial class UserService : IUserService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<User> AddUserAsync(User user) =>
            TryCatch(async () =>
            {
                ValidateUserOnAdd(user);

                return await this.storageBroker.InsertUserAsync(user);
            });
    }
}
