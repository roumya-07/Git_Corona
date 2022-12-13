using Git_Corona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
    public interface IUserRepository
    {
        public Task<int> SaveUpdate(UserEntity ue);
        public Task<UserEntity> GetByID(string UserID);
        public Task<UserEntity> GetByUserID(string UserId, string Pswd);
    }
}
