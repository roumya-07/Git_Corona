using Git_Corona.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
   public interface IBlockRepository
    {

         Task<List<Block>> GetAll();

         Task<Block> GetByID(string UserID);
         Task<List<Block>> GetByID(int ID);


         Task<Block> GetByUserID(string ID, string Pwd);

         Task<int> UpdateCreateData(Block obj);
      
    }
}
