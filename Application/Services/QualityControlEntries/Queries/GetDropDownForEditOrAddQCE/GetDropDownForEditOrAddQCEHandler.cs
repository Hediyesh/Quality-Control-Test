using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetDropDownForEditOrAddQCE
{
    public class GetDropDownForEditOrAddQCEHandler : IRequestHandler<GetDropDownForEditOrAddQCEQuery, GetDropDownForEditOrAddQCEDto>
    {
        private readonly IDataBaseContext _db;
        public GetDropDownForEditOrAddQCEHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<GetDropDownForEditOrAddQCEDto> Handle(GetDropDownForEditOrAddQCEQuery request, CancellationToken cancellationToken)
        {
            var qce = _db.QualityControlEntries
                .Include(x=> x.Machine)
                //* .Include(x=> x.Person)
                .Include(x => x.Product)
                .Include(x => x.Company)
                .Include(x => x.Batch)
                .Include(x => x.Severity)
                .Include(x => x.Defect)
                .Where(w=> w.QCEId == request.QCEId).SingleOrDefault();
            GetDropDownForEditOrAddQCEDto dto = new GetDropDownForEditOrAddQCEDto();
            dto.Batches = _db.Batchs.Select(s=> new BatchDto { BatchId = s.BatchId, BatchNumber = s.BatchNumber}).ToList();
            dto.Companies = _db.Companies.Select(s=> new CompanyDto { 
                Address = s.Address,
                CompanyId = s.CompanyId,
                CompanyName = s.CompanyName,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber
            }).ToList();
            dto.Severities = _db.Severities.Select(s=> new SeverityDto { SeverityId = s.SeverityId, SeverityDescription = s.SeverityDescription}).ToList();
            dto.Defects = _db.Defects.Select(s=> new DefectDto { DefectId = s.DefectId, DefectType = s.DefectType}).ToList();
            dto.Machines = _db.Machines.Select(s=> new MachineDto { CompanyId = s.CompanyId, MachineId = s.MachineId, MachineName = s.MachineName}).ToList();
            dto.Persons = new List<PersonDto> { };// * _db.Persons.Select(s=> new PersonDto { FirstName = s.FirstName, LastName = s.LastName, PersonId = s.PersonId}).ToList();
            dto.Products = _db.Products.Select(s=> new ProductDto {
                CompanyId = s.CompanyId,
                CategoryId = s.CategoryId,
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductSKU = s.ProductSKU   
            }).ToList();
            if (qce != null)
            {
                dto.PersonId = qce.PersonId;
                dto.PersonName = "";//* qce.Person?.FirstName + " " + qce.Person?.LastName;
                dto.ProductId = qce.ProductId;
                dto.ProductName = qce.Product.ProductName;
                dto.CompanyId = qce.CompanyId;
                dto.CompanyName = qce.Company.CompanyName;
                dto.BatchId = qce.BatchId;
                dto.BatchNumber = qce.Batch.BatchNumber;
                dto.DefectId = qce.DefectId;
                dto.DefectName = qce.Defect.DefectType;
                dto.MachineId = qce.MachineId;
                dto.MachineName = qce.Machine?.MachineName;
                dto.SeverityId = qce.SeverityId;
                dto.SeverityName = qce.Severity.SeverityDescription;
                dto.QualityDefective = qce.QualityDefective;
                dto.QuantityInspected = qce.QuantityInspected;
                dto.DefectDescription = qce.DefectDescription;
                dto.RootCause = qce.RootCause;
                dto.CorrectiveAction = qce.CorrectiveAction;
                dto.InspectionDate = qce.InspectionDate;
                dto.qceId = qce.QCEId;
            }
            return Task.FromResult(dto);
        }
    }
}
