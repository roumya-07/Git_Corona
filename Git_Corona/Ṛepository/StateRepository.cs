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
    public class StateRepository : BaseRepository, IStateRepository
    {
        string spName = "Sp_CoronaDetails";
        public StateRepository(IConfiguration conf) : base(conf)
        {

        }

        public async Task<List<State>> GetAll()
        {
            var con = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Sselect");
            var _user = await con.QueryAsync<State>(spName, param, commandType: CommandType.StoredProcedure);
            return _user.ToList();
        }
    }
}
