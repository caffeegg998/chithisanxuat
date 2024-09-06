using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models
{
    public class NguoiDung
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Section { get; set; }
        public string Grade { get; set; }
        public virtual ICollection<ChiThiPheDuyet_ChiTiet> ChiThiPheDuyetChiTiets { get; set; }

        public virtual ICollection<ChiThiPheDuyet> ChiThiPheDuyets { get; set; }
    }
}
