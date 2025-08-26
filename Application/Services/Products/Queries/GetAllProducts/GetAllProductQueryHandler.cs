using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;


namespace ControlService.ControlApplication.Services.Products.Queries.GetAllProducts
{

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetProductsDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllProductQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<List<GetProductsDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = _db.Products
                .Include(x=> x.Machines).ToList();
            //if (products == null)
            //{
            //    //return HttpNotFound();
            //}
            List<GetProductsDto> dtos = new List<GetProductsDto>();
            foreach (var product in products)
            {
                GetProductsDto dtop = new GetProductsDto();
                dtop.ProductId = product.ProductId;
                dtop.ProductName = product.ProductName;
                dtop.CategoryName = _db.Categories.Where(w => w.CategoryId == product.CategoryId).Single().CategoryName;
                dtop.CompanyName = _db.Companies.Where(w => w.CompanyId == product.CompanyId).Single().CompanyName;
                dtop.Machines = product.Machines?.Select(s => new GetProductMachineDto { id = s.MachineId, Name = s.MachineName }).ToList(); 
                dtop.CategoryId = product.CategoryId;
                dtop.CompanyId = product.CompanyId;
                dtos.Add(dtop);
            }

            return Task.FromResult(dtos);
        }
    }
}
