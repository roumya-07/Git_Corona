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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public async Task<int> SaveUpdate(UserEntity ue)
        {
            var cn = CreateConnection();
            if (cn.State == ConnectionState.Closed) cn.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@ID", ue.ID);
            param.Add("@UserID", ue.UserID);
            param.Add("@UserName", ue.UserName);
            param.Add("@Password", ue.Password);
            param.Add("@PhoneNo", ue.PhoneNo);
            param.Add("@Email", ue.Email);
            param.Add("@action", "Uinsert");
            int x = cn.Execute("Sp_CoronaDetails", param, commandType: CommandType.StoredProcedure);
            cn.Close();
            return x;
        }
        public async Task<UserEntity> GetByID(string UserId)
        {
            var cn = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", UserId);
            param.Add("@action", "USelect");
            var lstprod = cn.Query<UserEntity>("Sp_CoronaDetails", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstprod;
        }
        public async Task<UserEntity> GetByUserID(string UserId, string Pswd)
        {
            var cn = CreateConnection();
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserID", UserId);
            param.Add("@Password", Pswd);
            param.Add("@action", "USelect");
            var lstprod = cn.Query<UserEntity>("Sp_CoronaDetails", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            cn.Close();
            return lstprod;
        }
    }
}
