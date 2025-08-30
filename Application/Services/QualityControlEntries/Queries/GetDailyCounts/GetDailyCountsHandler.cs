using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts
{
    public class GetDailyCountsHandler : IRequestHandler<GetDailyCountsQuery, List<DailyCountDto>>
    {
        private readonly IDataBaseContext _db;
        public GetDailyCountsHandler(IDataBaseContext db) => _db = db;

        public async Task<List<DailyCountDto>> Handle(GetDailyCountsQuery request, CancellationToken cancellationToken)
        {
            return await _db.QualityControlEntries
                .GroupBy(q => q.InspectionDate.Date) // فقط سال، ماه، روز
                .Select(g => new DailyCountDto
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToListAsync(cancellationToken);
        }
    }
}
