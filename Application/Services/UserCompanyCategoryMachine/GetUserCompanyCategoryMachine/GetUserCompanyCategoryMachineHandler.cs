using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.UserCompanyCategoryMachine.GetUserCompanyCategoryMachine
{
    public class GetUserCompanyCategoryMachineHandler : IRequestHandler<GetUserCompanyCategoryMachineQuery, GetUserCompanyCategoryMachineDto>
    {
        private readonly IDataBaseContext _db;
        public GetUserCompanyCategoryMachineHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<GetUserCompanyCategoryMachineDto> Handle(GetUserCompanyCategoryMachineQuery request, CancellationToken cancellationToken)
        {
            // * need connection to user
            //var user = _db.Users.Where(w => w.UserName == request.UserName).First();
            var product = _db.Products.
                 Include(p => p.Machines)
                .Include(x => x.Company)
                .Include(x => x.Category)
                .Where(w => w.ProductId == request.ProductId).FirstOrDefault();
            GetUserCompanyCategoryMachineDto result = new GetUserCompanyCategoryMachineDto();
            GetProductsDto productDto;
            if (product == null)
            {
                productDto = null;
            }
            else
            {
                productDto = new GetProductsDto
                {
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    CompanyId = product.CompanyId,
                    CompanyName = product.Company.CompanyName,
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Machines = product.Machines?.Select(s => new GetProductMachineDto { id = s.MachineId, Name = s.MachineName }).ToList(),
                };
            }
            result.Product = productDto;
            result.CompanyId = 1 ;// * (int)user.CompanyId
            result.CompanyName = "پایا";//* _db.Companies.Where(w => w.CompanyId == user.CompanyId).First().CompanyName;
            result.UserName = request.UserName;
            // * if had the arguement user.companyid == 1
            if (result.CompanyId == 1)
            {
                result.companies = _db.Companies.Select(s => new CompanyDto
                {
                    CompanyId = s.CompanyId,
                    CompanyName = s.CompanyName,
                    Address = s.Address,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber
                }).ToList();
                result.machines = _db.Machines.Select(s => new GetProductMachineDto { id = s.MachineId, Name = s.MachineName }).ToList();
                result.categories = _db.Categories.Select(s => new CategoryDto { CategoryId = s.CategoryId, CategoryName = s.CategoryName }).ToList();
            }
            else
            {
                result.machines = _db.Machines.Where(m => m.CompanyId == result.CompanyId).Select(s => new GetProductMachineDto
                {
                    id = s.MachineId,
                    Name = s.MachineName
                }).ToList();
                result.categories = _db.Categories.Where(m => m.CompanyId == result.CompanyId).Select(s => new CategoryDto
                {
                    CategoryId = s.CategoryId,
                    CategoryName = s.CategoryName
                }).ToList();
                result.companies = null;
            }
            if (product != null)
            {
                result.selectedMachines = product.Machines?.Select(s => new GetProductMachineDto
                {
                    id = s.MachineId,
                    Name = s.MachineName
                }).ToList();
            }
            return Task.FromResult(result);
        }
    }
}
