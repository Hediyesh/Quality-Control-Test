using ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetFeature
{
    public class GetFeatureQuery: IRequest<FeatureDto>
    {
        public Guid Id { get; set; }
    }
}
