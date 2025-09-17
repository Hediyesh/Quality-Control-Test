using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Queries.GetAllFeaturesTree
{
    public class GetAllFeaturesTreeQuery: IRequest<List<FeatureDto>>
    {
    }
}
