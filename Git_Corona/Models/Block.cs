using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Models
{
    public class Block
    {
        [Key]
        public int BlockID { get; set; }
        public int StateID { get; set; }
        public String BlockName { get; set; }
    }
}
