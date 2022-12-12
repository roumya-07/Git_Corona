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
    public class BlockRepository:BaseRepository
    {
        string spName = "Sp_CoronaDetails";
    public BlockRepository(IConfiguration conf) : base(conf)
    {

    }

    public Task<List<Block>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Block> GetByID(string UserID)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Block>> GetByID(int ID)
    {
        var con = CreateConnection();
        DynamicParameters param = new DynamicParameters();
        param.Add("@action", "Bselect");
        param.Add("@stateID", ID);

        var x = await con.QueryAsync<Block>(spName, param, commandType: CommandType.StoredProcedure);
        return x.ToList();
    }

    public Task<Block> GetByUserID(string ID, string Pwd)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateCreateData(Block obj)
    {
        throw new NotImplementedException();
    }
}
}
