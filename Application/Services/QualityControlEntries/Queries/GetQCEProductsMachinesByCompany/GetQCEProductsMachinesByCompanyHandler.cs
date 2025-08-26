using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQCEProductsMachinesByCompany
{
    public class GetQCEProductsMachinesByCompanyHandler : IRequestHandler<GetQCEProductsMachinesByCompanyQuery, GetQCEProductsMachinesByCompanyDto>
    {
        private readonly IDataBaseContext _db;
        public GetQCEProductsMachinesByCompanyHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<GetQCEProductsMachinesByCompanyDto> Handle(GetQCEProductsMachinesByCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = _db.Companies.Where(w => w.CompanyId == request.companyId).FirstOrDefault();
            if (company == null)
            {
                throw new ArgumentException("شرکتی با این نام وجود ندارد!");
            }
            var products = _db.Products.Where(w => w.CompanyId == company.CompanyId).Select(s=> new ProductDto
            {
                CompanyId = s.CompanyId,
                CategoryId = s.CategoryId,
                ProductId = s.ProductId,
                ProductName = s.ProductName,
                ProductSKU = s.ProductSKU
            }).ToList();
            var machines = _db.Machines.Where(w => w.CompanyId == company.CompanyId).Select(s=> new MachineDto
            {
                CompanyId = s.CompanyId,
                MachineId = s.MachineId,
                MachineName = s.MachineName,
            }).ToList();
            return Task.FromResult(new GetQCEProductsMachinesByCompanyDto
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Machines = machines,
                Products = products
            });

        }
    }
}
