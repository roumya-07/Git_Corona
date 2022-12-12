using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Models
{
    public class CoronaStatus
    {
        [Key]
        public int CoronaID { get; set; }
        [Required]
        public int PanchyatID { get; set; }
        [Required]
        public string CitizenName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AffectedDate { get; set; }
        [Required]
        public int Status { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public int Death { get; set; }
        [NotMapped]
        public int Affected { get; set; }
    }
}
