using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetDataForEditOrAddML
{
    public class GetDataForEditOrAddMLHandler: IRequestHandler<GetDataForEditOrAddMLQuery, GetDataForEditOrAddMLDto>
    {
        private readonly IDataBaseContext _db;
        public GetDataForEditOrAddMLHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<GetDataForEditOrAddMLDto> Handle(GetDataForEditOrAddMLQuery request, CancellationToken cancellationToken)
        {
            var machines = _db.Machines.ToList();
            var persons = new { }; //* _db.Persons.ToList();
            var statuses = _db.MaintenanceLogStatuses.ToList();
            var types = _db.MaintenanceTypes.ToList();
            var companies = _db.Companies.ToList();
            var ml = _db.MaintenanceLogs
                .Include(x=> x.Machine)
                // * .Include(x=> x.Person)
                .Include(x=> x.MaintenanceLogStatus)
                .Include(x=> x.Company)
                .Include(x=> x.MaintenanceType)
                .Where(w=> w.MLId == request.MLId).SingleOrDefault();
            var dto = new GetDataForEditOrAddMLDto();
            dto.machines = machines;
            // * dto.persons = persons;
            dto.statuses = statuses;
            dto.maintenanceTypes = types;
            dto.companies = companies;
            if (ml != null)
            {
                dto.MLId = ml.MLId;
                dto.MLDate = ml.MaintenanceDate;
                dto.NextScheduleDate = ml.NextScheduleDate;
                dto.Description = ml.Description;
                dto.HoursSpent = ml.HoursSpent;
                dto.MachineId = ml.MachineId;
                dto.PersonId = ml.PersonId;
                dto.MachineName = ml.Machine.MachineName;
                dto.PersonName = "";// * ml.Person?.FirstName + " " + ml.Person?.LastName;
                dto.StatusId = ml.MaintenanceLogStatusId;
                dto.StatusName = ml.MaintenanceLogStatus.Status;
                dto.MaintenanceTypeId = ml.MaintenanceId;
                dto.MaintenanceTypeName = ml.MaintenanceType.MaintenanceTypeName;
                dto.CompanyId = ml.CompanyId;
                dto.CompanyName = ml.Company.CompanyName;
            }
            return Task.FromResult(dto);
        }
    }
}
