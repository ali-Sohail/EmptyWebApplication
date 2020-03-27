using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{ 
    public partial class DaliyLog
    {
        public int? Id { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime? OutDateTime { get; set; }
        [Required]
        public DateTime LogDate { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
