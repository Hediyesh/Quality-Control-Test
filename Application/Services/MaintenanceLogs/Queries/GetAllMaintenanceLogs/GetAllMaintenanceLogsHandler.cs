using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs
{
    public class GetAllMaintenanceLogsHandler: IRequestHandler<GetAllMaintenanceLogsQuery, List<GetMaintenanceLogsDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllMaintenanceLogsHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<List<GetMaintenanceLogsDto>> Handle(GetAllMaintenanceLogsQuery request, CancellationToken cancellationToken)
        {
            var mls = _db.MaintenanceLogs
                //* .Include(s=> s.Person)
                .ToList();
            return Task.FromResult(mls.Select(s => new GetMaintenanceLogsDto
            {
                CompanyName = _db.Companies.Where(w=>w.CompanyId == s.CompanyId).Single().CompanyName,
                Description = s.Description,
                HoursSpent = s.HoursSpent,
                MachineName = _db.Machines.Where(w => w.MachineId == s.MachineId).Single().MachineName,
                MaintenanceDate = SetToPersianDate.ToShamsiDate(s.MaintenanceDate),
                MaintenanceLogStatusName = _db.MaintenanceLogStatuses.Where(w => w.StatusId == s.MaintenanceLogStatusId).Single().Status,
                MaintenanceTypeName = _db.MaintenanceTypes.Where(w => w.MaintenanceId == s.MaintenanceId).Single().MaintenanceTypeName,
                MLId = s.MLId,
                NextScheduleDate = s.NextScheduleDate != null ? SetToPersianDate.ToShamsiDate(s.NextScheduleDate.Value) : "",
                PersonName = "" //*  s.Person?.FirstName + " " + s.Person?.LastName
            }).ToList());
        }
    }
}
