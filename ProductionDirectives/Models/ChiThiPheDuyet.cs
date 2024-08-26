using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ChiThiPheDuyet : ChiThiMau
    {
        public bool isDandory_Done { get; set; }
        public DateTime CreateAt { get; set; }
        public Guid PICCreate { get; set; }
        public string Shift { get; set; }
    }

}
