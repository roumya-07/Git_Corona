using Dapper;
using Git_Corona.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
    public class PanchyatRepository : BaseRepository, IPanchyatRepository
    {
        string spName = "Sp_CoronaDetails";
        public PanchyatRepository(IConfiguration conf) : base(conf)
        {

        }

        public Task<List<Panchyat>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Panchyat> GetByID(string UserID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Panchyat>> GetByID(int ID)
        {
            var con = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Pselect");
            param.Add("@BlockID", ID);

            var x = await con.QueryAsync<Panchyat>(spName, param, commandType: CommandType.StoredProcedure);
            return x.ToList();
        }

        public Task<Panchyat> GetByUserID(string ID, string Pwd)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCreateData(Panchyat obj)
        {
            throw new NotImplementedException();
        }
    }
}
