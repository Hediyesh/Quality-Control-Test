using ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetAllFeatures
{
    public class GetAllFeaturesQuery: IRequest<List<FeatureDto>>
    {
    }
}
