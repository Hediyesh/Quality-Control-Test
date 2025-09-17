using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetAllFeaturesTree
{
    public class GetAllFeaturesTreeQueryHandler: IRequestHandler<GetAllFeaturesTreeQuery, List<FeatureDto>>
    {
        private readonly IDataBaseContext _context;
        public GetAllFeaturesTreeQueryHandler(IDataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<FeatureDto>> Handle(GetAllFeaturesTreeQuery request, CancellationToken cancellationToken)
        {
            // 1. گرفتن همه نودها به صورت flat list
            var flatList = await _context.Features
                .Select(f => new FeatureDto
                {
                    Id = f.Id,
                    NodeId = f.NodeId,
                    Label = f.Label,
                    NodePath = f.Node.ToString() // hierarchyid -> string
                })
                .OrderBy(f => f.NodePath) // مرتب‌سازی برای اطمینان از ترتیب
                .ToListAsync();

            // 2. دیکشنری برای دسترسی سریع به نودها
            var dict = flatList.ToDictionary(f => f.NodePath);

            var roots = new List<FeatureDto>();

            foreach (var node in flatList)
            {
                // اگر NodePath سطح اول است (Root)
                if (node.NodePath.Count(c => c == '/') == 2) // مثال: "/" و "/1/" => count '/'
                {
                    roots.Add(node);
                }
                else
                {
                    // پیدا کردن والد: حذف آخرین بخش از NodePath
                    var parentPath = node.NodePath.TrimEnd('/'); // /1/1/1 -> /1/1
                    parentPath = parentPath.Substring(0, parentPath.LastIndexOf('/') + 1);

                    if (dict.TryGetValue(parentPath, out var parent))
                    {
                        parent.Children.Add(node);
                    }
                }
            }

            return roots;

        }
    }
}
