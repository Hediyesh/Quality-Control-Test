using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
    {
        private readonly IDataBaseContext _db;
        public GetAllCategoriesQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Categories.Select(x=> new CategoryDto()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
            }).OrderByDescending(x=> x.CategoryId).ToList());
        }
    }
}
