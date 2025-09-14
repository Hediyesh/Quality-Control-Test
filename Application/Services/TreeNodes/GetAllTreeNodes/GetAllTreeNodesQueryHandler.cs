using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.TreeNodes.GetAllTreeNodes
{
    public class GetAllTreeNodesQueryHandler : IRequestHandler<GetAllTreeNodesQuery, TreeNodeDto>
    {
        private readonly IDataBaseContext _db;
        public GetAllTreeNodesQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public Task<TreeNodeDto> Handle(GetAllTreeNodesQuery request, CancellationToken cancellationToken)
        {
            var root = new TreeNodeDto()
            {
                Id = 1,
                Type = Types.Root,
                Label = "Root",
            };
            var Companies = _db.Companies.ToList();
            foreach ( var company in Companies)
            {
                var companyDto = new TreeNodeDto()
                {
                    Id = company.CompanyId,
                    Label = company.CompanyName,
                    Type = Types.Company
                };
                root.Children.Add(companyDto);

                var Machines = _db.Machines.Where(w=> w.CompanyId == company.CompanyId).ToList();
                foreach( var machine in Machines)
                {
                    var machineDto = new TreeNodeDto()
                    {
                        Id = machine.MachineId,
                        Label = machine.MachineName,
                        Type = Types.Machine
                    };
                    companyDto.Children.Add(machineDto);

                    var categories = _db.Categories.ToList();
                    foreach( var category in categories)
                    {
                        var products = _db.Products
                        .Where(p => p.CompanyId == company.CompanyId
                                 && p.CategoryId == category.CategoryId
                                 && p.Machines.Any(m => m.MachineId == machine.MachineId))
                        .ToList();

                        if (products.Count > 0)
                        {
                            var categoryDto = new TreeNodeDto()
                            {
                                Id = category.CategoryId,
                                Label = category.CategoryName,
                                Type = Types.Category
                            };
                            machineDto.Children.Add(categoryDto);

                            foreach (var product in products)
                            {
                                var productDto = new TreeNodeDto()
                                {
                                    Id = product.ProductId,
                                    Label = product.ProductName,
                                    Type = Types.Product
                                };
                                categoryDto.Children.Add(productDto);
                            }
                        }
                    }
                }
            }
            return Task.FromResult(root);
        }
    }
}
