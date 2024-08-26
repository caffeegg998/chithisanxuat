using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ChiThiMau
    {
        public Guid Id { get; set; }
        public string LineName { get; set; }
        public string ModelName { get; set; }
        public int TotalStage { get; set; }
        public int TotalStep { get; set; }

        public virtual ICollection<ChiThiMau_ChiTiet> ChiTiets { get; set; }
    }
}
