using Git_Corona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
    public interface ICoronaRepository
    {
        Task<List<CoronaStatus>> GetAll();
        Task<int> UpdateCreateData(CoronaStatus obj);
    }
}
