using ControlDomain.Entities;
using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetFeature
{
    public class GetFeatureQueryHandler: IRequestHandler<GetFeatureQuery, FeatureDto>
    {
        private readonly IDataBaseContext _context;
        public GetFeatureQueryHandler(IDataBaseContext context)
        {
            _context = context;
        }

        public Task<FeatureDto> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var feature = _context.Features.Where(w=> w.Id == request.Id).FirstOrDefault();
            if (feature == null)
                return Task.FromResult(new FeatureDto());
            return Task.FromResult(new FeatureDto()
            {
                Id = request.Id,
                Label = feature.Label,
                Node = feature.Node,
                NodeId = feature.NodeId,
                Type = feature.Type
            });
        }
    }
}
