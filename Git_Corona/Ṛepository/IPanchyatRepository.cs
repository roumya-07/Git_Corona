using Git_Corona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
   public interface IPanchyatRepository
    {


         Task<List<Panchyat>> GetAll();


         Task<Panchyat> GetByID(string UserID);


         Task<List<Panchyat>> GetByID(int ID);


         Task<Panchyat> GetByUserID(string ID, string Pwd);

         Task<int> UpdateCreateData(Panchyat obj);
      

    }
}
