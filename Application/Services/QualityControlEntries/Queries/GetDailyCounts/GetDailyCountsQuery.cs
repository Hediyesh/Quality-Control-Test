using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts
{
    public class GetDailyCountsQuery : IRequest<List<DailyCountDto>> { }

    public class DailyCountDto
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
