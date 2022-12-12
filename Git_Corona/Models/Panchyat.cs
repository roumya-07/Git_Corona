using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Models
{
    public class Panchyat
    {
        [Key]
        public int PanchyatID { get; set; }
        public int BlockID { get; set; }
        public string PanchyatName { get; set; }
    }
}
