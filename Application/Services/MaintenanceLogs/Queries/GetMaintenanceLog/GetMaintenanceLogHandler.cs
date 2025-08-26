using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetMaintenanceLog
{
    public class GetMaintenanceLogHandler: IRequestHandler<GetMaintenanceLogQuery, GetMaintenanceLogsDto>
    {
        private readonly IDataBaseContext _db;
        public GetMaintenanceLogHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<GetMaintenanceLogsDto> Handle(GetMaintenanceLogQuery request, CancellationToken cancellationToken)
        {
            var ml = _db.MaintenanceLogs.Where(s => s.MLId == request.mlId).SingleOrDefault();
            if (ml == null) { 
                return Task.FromResult(new GetMaintenanceLogsDto { });
            }
            return Task.FromResult(new GetMaintenanceLogsDto
            {
                CompanyName = _db.Companies.Where(w=>w.CompanyId == ml.CompanyId).Single().CompanyName,
                Description = ml.Description,
                HoursSpent = ml.HoursSpent,
                MachineName = _db.Machines.Where(w => w.MachineId == ml.MachineId).Single().MachineName,
                MaintenanceDate = SetToPersianDate.ToShamsiDate(ml.MaintenanceDate),
                MaintenanceLogStatusName = _db.MaintenanceLogStatuses.Where(w => w.StatusId == ml.MaintenanceLogStatusId).Single().Status,
                MaintenanceTypeName = _db.MaintenanceTypes.Where(w => w.MaintenanceId == ml.MaintenanceId).Single().MaintenanceTypeName,
                MLId = ml.MLId,
                NextScheduleDate = ml.NextScheduleDate != null ? SetToPersianDate.ToShamsiDate(ml.NextScheduleDate.Value) : "",
                PersonName = ""//* ml.Person?.FirstName + " " + ml.Person?.LastName
            });
        }
    }
}
