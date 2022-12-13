using Git_Corona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Ṛepository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAll();
    }
}
