using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, GetProductsDto>
    {
        private readonly IDataBaseContext _db;
        public GetProductHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<GetProductsDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _db.Products
                .Include(x => x.Machines)
                .Where(w => w.ProductId == request.ProductId).FirstOrDefault();
            if (product == null)
            {
                return Task.FromResult(new GetProductsDto { });
            }
            return Task.FromResult(new GetProductsDto
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                CategoryName = _db.Categories.Where(w => w.CategoryId == product.CategoryId).Single().CategoryName,
                CompanyId = product.CompanyId,
                CompanyName = _db.Companies.Where(w => w.CompanyId == product.CompanyId).Single().CompanyName,
                Machines = product.Machines?.Select(s => new GetProductMachineDto { id = s.MachineId, Name = s.MachineName }).ToList(),
                ProductName = product.ProductName
            });
        }
    }
}
