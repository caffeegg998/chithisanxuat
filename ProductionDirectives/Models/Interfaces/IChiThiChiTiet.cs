using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionDirectives.Models.Interfaces
{
    //Đặc tả thuộc tính chung của chỉ thị
    public interface IChiThiChiTiet
    {
        Guid Id { get; set; }
        string LineName { get; set; }
        string ModelName { get; set; }
        string Stage { get; set; }
        int NumberOrder { get; set; }
        string Step { get; set; }
        string RuleStandard { get; set; }
    }
}
