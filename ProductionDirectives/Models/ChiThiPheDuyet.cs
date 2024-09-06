using ProductionDirectives.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class ChiThiPheDuyet : IChiThiMau
    {
       
        public Guid Id { get; set; }
        public string LineName { get; set; }
        public string ModelName { get; set; }
        public int TotalStage { get; set; }
        public int TotalStep { get; set; }
        public bool isDandory_Done { get; set; }
        public DateTime CreateAt { get; set; }
        
        public string Shift { get; set; }

        public Guid PICCreate { get; set; }
        public virtual NguoiDung PICCreateNguoiDung { get; set; }
        public virtual ICollection<ChiThiPheDuyet_ChiTiet> ChiThiPheDuyet_ChiTiets { get; set; }
    }

}
