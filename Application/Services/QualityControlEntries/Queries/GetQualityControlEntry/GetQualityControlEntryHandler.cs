using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetAllQualityControlEntries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQualityControlEntry
{
    public class GetQualityControlEntryHandler: IRequestHandler<GetQualityControlEntryQuery, GetQualityControlEntriesDto>
    {
        private readonly IDataBaseContext _db;
        public GetQualityControlEntryHandler(IDataBaseContext db) { _db = db; }

        public Task<GetQualityControlEntriesDto> Handle(GetQualityControlEntryQuery request, CancellationToken cancellationToken)
        {
            var ql = _db.QualityControlEntries.Where(s => s.QCEId == request.qle).SingleOrDefault();
            if (ql == null)
            {
                return Task.FromResult(new GetQualityControlEntriesDto { });
            }
            return Task.FromResult(new GetQualityControlEntriesDto
            {
                BatchNumber = _db.Batchs.Where(w => w.BatchId == ql.BatchId).Single().BatchNumber,
                CompanyName = _db.Companies.Where(w => w.CompanyId == ql.CompanyId).Single().CompanyName,
                CorrectiveAction = ql.CorrectiveAction,
                Defect = _db.Defects.Where(w => w.DefectId == ql.DefectId).Single().DefectType,
                DefectDescription = ql.DefectDescription,
                InspectionDate = SetToPersianDate.ToShamsiDate(ql.InspectionDate),
                MachineName = _db.Machines.Where(w => w.MachineId == ql.MachineId).Single().MachineName,
                ProductName = _db.Products.Where(w => w.ProductId == ql.ProductId).Single().ProductName,
                QCEId = ql.QCEId,
                QualityDefective = ql.QualityDefective,
                QuantityInspected = ql.QuantityInspected,
                RootCause = ql.RootCause,
                Severity = _db.Severities.Where(w => w.SeverityId == ql.SeverityId).Single().SeverityDescription,
                PersonName = ""//*_db.Persons.Where(w => w.PersonId == ql.PersonId).SingleOrDefault()?.FirstName + " " + _db.Persons.Where(w => w.PersonId == ql.PersonId).SingleOrDefault()?.LastName
            });
        }
    }
}
