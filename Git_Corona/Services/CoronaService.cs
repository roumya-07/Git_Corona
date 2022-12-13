using Git_Corona.Models;
using Git_Corona.Ṛepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Git_Corona.Services;
using Git_Corona.Ṛepository;

namespace Git_Corona.Services
{
    public class CoronaService:ICoronaService
    {
        private readonly ICoronaRepository _CoronaRepo = null;
        private readonly IUserRepository _UserRepo = null;
        private readonly IStateRepository _stateRepo = null;
        private readonly IBlockRepository _blockRepo = null;
        private readonly IPanchyatRepository _panchayRepo = null;
        public CoronaService(ICoronaRepository corona, IUserRepository user, IStateRepository state, IBlockRepository block, IPanchyatRepository panchy)
        {
            _CoronaRepo = corona;
            _UserRepo = user;
            _stateRepo = state;
            _blockRepo = block;
            _panchayRepo = panchy;
        }

        public async Task<List<Block>> BlockGetAll(int ID)
        {
            return await _blockRepo.GetByID(ID);

        }

        public async Task<List<CoronaStatus>> CoronaGetAll()
        {
            return await _CoronaRepo.GetAll();
        }

        public async Task<int> CoronaUpdateCreateData(CoronaStatus obj)
        {
            return await _CoronaRepo.UpdateCreateData(obj);
        }

        public async Task<List<Panchyat>> PanchyatGetAll(int ID)
        {
            return await _panchayRepo.GetByID(ID);
        }

        public async Task<List<State>> StateGetAll()
        {
            return await _stateRepo.GetAll();
        }

        public async Task<int> UserCreate(UserEntity obj)
        {
            return await _UserRepo.SaveUpdate(obj);
        }

        public Task<List<UserEntity>> UserGetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserEntity> UserGetByUserID(string UserID, string Pwd)
        {
            return await _UserRepo.GetByUserID(UserID, Pwd);
        }

        public async Task<UserEntity> UserGetByUserID(string UserID)
        {
            return await _UserRepo.GetByID(UserID);
        }

        public async Task<int> UserUpdateCreateData(UserEntity obj)
        {
            return await _UserRepo.SaveUpdate(obj);
        }
    }
}
