using ProductionDirectives.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ChiThiPheDuyet_ChiTiet : IChiThiChiTiet
    {
        public Guid Id { get; set; }
        public string LineName { get; set; }
        public string ModelName { get; set; }
        public string Stage { get; set; }
        public int NumberOrder { get; set; }
        public string Step { get; set; }
        public string RuleStandard { get; set; }
        public string Actual { get; set; }
        public bool Result { get; set; }
        public DateTime LastChecked { get; set; }
        public Guid Id_ChiThiPheDuyet { get; set; }
    }
}
