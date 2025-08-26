using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;

        public DeleteProductHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _db.Products
                .Include(x => x.Machines)
                .FirstOrDefault(w => w.ProductId == request.ProductId);

            if (product == null)
                return ResultDto.Fail("محصول مورد نظر یافت نشد.");

            product.Machines?.Clear(); // پاک کردن ارتباط‌ها
            _db.Products.Remove(product);

            await _db.SaveChangesAsync(cancellationToken);

            return ResultDto.Success("محصول با موفقیت حذف شد.");
        }
    }

}
