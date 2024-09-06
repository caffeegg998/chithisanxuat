using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ChartModel
    {
        public string lineName_Group { get; set; }
        public int position_Group { get; set; }
        public int total_ChiThi { get; set; }
        public List<ScottPlot.Bar> bars { get; set; }

        public ChartModel()
        {
            bars = new List<ScottPlot.Bar>();
        }
    }
}
