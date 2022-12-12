using Git_Corona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Services
{
    public interface ICoronaService
    {
        Task<int> UserCreate(UserEntity obj);
        Task<List<UserEntity>> UserGetAll();
        Task<UserEntity> UserGetByUserID(string UserID);
        Task<UserEntity> UserGetByUserID(string UserID, string Pwd);

        Task<int> UserUpdateCreateData(UserEntity obj);

        Task<List<CoronaStatus>> CoronaGetAll();

        Task<int> CoronaUpdateCreateData(CoronaStatus obj);

        Task<List<State>> StateGetAll();
        Task<List<Block>> BlockGetAll(int ID);
        Task<List<Panchyat>> PanchyatGetAll(int ID);
    }
}
