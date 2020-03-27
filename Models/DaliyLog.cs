using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{ 
    public partial class DaliyLog
    {
        public int Id { get; set; }
        public DateTime InDateTime { get; set; }
        public DateTime? OutDateTime { get; set; }
        public DateTime LogDate { get; set; }

        public int UserId { get; set; }
    }
}
