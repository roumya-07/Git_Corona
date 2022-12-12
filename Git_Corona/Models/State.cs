using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string StateName { get; set; }
    }
}
