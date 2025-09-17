using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Commands.DeleteFeature
{
    public class DeleteFeatureQueryHandler: IRequestHandler<DeleteFeatureQuery, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public DeleteFeatureQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public async Task<ResultDto> Handle(DeleteFeatureQuery request, CancellationToken cancellationToken)
        {
            var feature = await _db.Features.Where(w=> w.Id == request.Id).FirstOrDefaultAsync();
            if (feature == null)
                return ResultDto.Fail("ویژگی وجود ندارد");
            if (request.Type == ControlDomain.Entities.Types.Product)
            {
                var product = _db.Products
                .Include(x => x.Machines)
                .FirstOrDefault(w => w.ProductId == request.NodeId);
                if (product == null)
                    return ResultDto.Fail("محصول مورد نظر یافت نشد.");
                product.Machines?.Clear(); // پاک کردن ارتباط‌ها
                _db.Products.Remove(product);
                _db.Features.Remove(feature);
            }
            if (request.Type == ControlDomain.Entities.Types.Company)
            {
                var company = await _db.Companies.Where(w => w.CompanyId == request.NodeId).FirstOrDefaultAsync();
                if (company == null)
                    return ResultDto.Fail("چنین شرکتی وجود ندارد");
                var products = await _db.Products.Where(w => w.CompanyId == request.NodeId).ToListAsync();
                var logs = await _db.MaintenanceLogs.Where(w => w.CompanyId == request.NodeId).ToListAsync();
                var categories = await _db.Categories.Where(w => w.CompanyId == request.NodeId).ToListAsync();
                var qces = await _db.QualityControlEntries.Where(w => w.CompanyId == request.NodeId).ToListAsync();
                var machines = await _db.Machines.Where(w => w.CompanyId == request.NodeId).ToListAsync();
                if (products.Count > 0 || logs.Count > 0 || categories.Count > 0 || qces.Count > 0 || machines.Count > 0)
                    return ResultDto.Fail("این شرکت به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
                _db.Companies.Remove(company);
                _db.Features.Remove(feature);
            }
            if (request.Type == ControlDomain.Entities.Types.Category)
            {
                var cat = await _db.Categories.Where(w => w.CategoryId == request.NodeId).FirstOrDefaultAsync();
                if (cat == null)
                    return ResultDto.Fail("چنین گروهی وجود ندارد");
                var products = await _db.Products.Where(w => w.CategoryId == request.NodeId).ToListAsync();
                if (products.Count > 0)
                    return ResultDto.Fail("این گروه به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
                _db.Categories.Remove(cat);
                _db.Features.Remove(feature);
            }
            if (request.Type == ControlDomain.Entities.Types.Machine)
            {
                var machine = await _db.Machines.Where(w => w.MachineId == request.NodeId).FirstOrDefaultAsync();
                if (machine == null)
                    return ResultDto.Fail("چنین دستگاهی وجود ندارد");
                var logs = await _db.MaintenanceLogs.Where(w => w.MachineId == request.NodeId).ToListAsync();
                var qces = await _db.QualityControlEntries.Where(w => w.MachineId == request.NodeId).ToListAsync();
                if (logs.Count > 0 || qces.Count > 0)
                    return ResultDto.Fail("این دستگاه به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
                _db.Machines.Remove(machine);
                _db.Features.Remove(feature);
            }
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت حذف شد");
        }
    }
}
