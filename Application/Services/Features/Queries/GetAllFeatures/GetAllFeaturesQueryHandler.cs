using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetAllFeatures
{
    public class GetAllFeaturesQueryHandler: IRequestHandler<GetAllFeaturesQuery, List<FeatureDto>>
    {
        private readonly IDataBaseContext _context;
        public GetAllFeaturesQueryHandler(IDataBaseContext context)
        {
            _context = context;
        }

        public Task<List<FeatureDto>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = _context.Features.Select(x=> new FeatureDto()
            {
                Id = x.Id,
                Label = x.Label,
                Node = x.Node,
                NodeId = x.NodeId,
                Type = x.Type,
            }).ToList();
            return Task.FromResult(features);
        }
    }
}
