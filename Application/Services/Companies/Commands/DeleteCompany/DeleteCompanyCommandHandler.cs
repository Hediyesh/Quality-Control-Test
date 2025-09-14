using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public DeleteCompanyCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _db.Companies.Where(w => w.CompanyId == request.Id).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("چنین شرکتی وجود ندارد");
            var products = await _db.Products.Where(w=> w.CompanyId == request.Id).ToListAsync();
            var logs = await _db.MaintenanceLogs.Where(w => w.CompanyId == request.Id).ToListAsync();
            var categories = await _db.Categories.Where(w => w.CompanyId == request.Id).ToListAsync();
            var qces = await _db.QualityControlEntries.Where(w => w.CompanyId == request.Id).ToListAsync();
            var machines = await _db.Machines.Where(w => w.CompanyId == request.Id).ToListAsync();
            if (products.Count > 0 || logs.Count > 0 || categories.Count > 0 || qces.Count > 0 || machines.Count > 0)
                return ResultDto.Fail("این شرکت به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
            _db.Companies.Remove(company);
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت حذف شد");
        }
    }
}
