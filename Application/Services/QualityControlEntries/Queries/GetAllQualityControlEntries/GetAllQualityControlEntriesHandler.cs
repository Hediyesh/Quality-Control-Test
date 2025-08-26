using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetAllQualityControlEntries
{
    public class GetAllQualityControlEntriesHandler : IRequestHandler<GetAllQualityControlEntriesQuery, List<GetQualityControlEntriesDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllQualityControlEntriesHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<List<GetQualityControlEntriesDto>> Handle(GetAllQualityControlEntriesQuery request, CancellationToken cancellationToken)
        {
            var qls = _db.QualityControlEntries.ToList();
            return Task.FromResult(qls.Select(s=> new GetQualityControlEntriesDto
            {
                BatchNumber = _db.Batchs.Where(w => w.BatchId == s.BatchId).Single().BatchNumber,
                CompanyName = _db.Companies.Where(w => w.CompanyId == s.CompanyId).Single().CompanyName,
                CorrectiveAction = s.CorrectiveAction,
                Defect = _db.Defects.Where(w=>w.DefectId == s.DefectId).Single().DefectType,
                DefectDescription = s.DefectDescription,
                InspectionDate = SetToPersianDate.ToShamsiDate(s.InspectionDate),
                MachineName = _db.Machines.Where(w=>w.MachineId == s.MachineId).Single().MachineName,
                ProductName = _db.Products.Where(w => w.ProductId == s.ProductId).Single().ProductName,
                QCEId = s.QCEId,
                QualityDefective = s.QualityDefective,
                QuantityInspected = s.QuantityInspected,
                RootCause = s.RootCause,
                Severity = _db.Severities.Where(w => w.SeverityId == s.SeverityId).Single().SeverityDescription,
                PersonName = ""//* _db.Persons.Where(w => w.PersonId == s.PersonId).SingleOrDefault()?.FirstName + " " + _db.Persons.Where(w => w.PersonId == s.PersonId).SingleOrDefault()?.LastName
            }).ToList());
        }
    }
}
