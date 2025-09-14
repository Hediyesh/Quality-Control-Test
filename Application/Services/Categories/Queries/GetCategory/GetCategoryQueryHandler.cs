using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Queries.GetCategory
{
    public class GetCategoryQueryHandler: IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IDataBaseContext _db;
        public GetCategoryQueryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var cat = _db.Categories.Where(w => w.CategoryId == request.Id).Select(x => new CategoryDto()
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                CompanyId = x.CompanyId,
                CompanyName = x.Company.CompanyName,
            }).FirstOrDefault();
            if (cat == null)
                return Task.FromResult(new CategoryDto());
            return Task.FromResult(cat);
        }
    }
}
