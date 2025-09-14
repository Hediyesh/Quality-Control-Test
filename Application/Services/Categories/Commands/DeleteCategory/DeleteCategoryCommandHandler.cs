using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public DeleteCategoryCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var cat = await _db.Categories.Where(w => w.CategoryId == request.Id).FirstOrDefaultAsync();
            if (cat == null)
                return ResultDto.Fail("چنین گروهی وجود ندارد");
            var products = await _db.Products.Where(w=> w.CategoryId == request.Id).ToListAsync();
            if (products.Count > 0)
                return ResultDto.Fail("این گروه به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت حذف شد");
        }
    }
}
