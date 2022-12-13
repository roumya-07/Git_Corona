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
    public class CoronaRepository : BaseRepository, ICoronaRepository
    {
        string spName = "Sp_CoronaDetails";
        public CoronaRepository(IConfiguration conf) : base(conf)
        {

        }

        public async Task<List<CoronaStatus>> GetAll()
        {
            var con = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Ccount");
            var _corona = await con.QueryAsync<CoronaStatus>(spName, param, commandType: CommandType.StoredProcedure);
            return _corona.ToList();
        }

        public async Task<int> UpdateCreateData(CoronaStatus obj)
        {
            var con = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@action", "Cinsert");
            param.Add("@PanchyatID", obj.PanchyatID);
            param.Add("@CitizenName", obj.CitizenName);
            param.Add("@AffectedDate", obj.AffectedDate);
            param.Add("@status", obj.Status);
            var x = await con.ExecuteAsync(spName, param, commandType: CommandType.StoredProcedure);
            return x;
        }
    }
}
