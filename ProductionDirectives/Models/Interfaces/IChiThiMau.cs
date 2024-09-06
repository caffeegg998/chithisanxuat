using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models.Interfaces
{
    public interface IChiThiMau
    {
        public Guid Id { get; set; }
        public string LineName { get; set; }
        public string ModelName { get; set; }
        public int TotalStage { get; set; }
        public int TotalStep { get; set; }
    }
}
