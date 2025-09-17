using ControlDomain.Entities;
using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Features.Commands.DeleteFeature
{
    public class DeleteFeatureQuery : IRequest<ResultDto>
    {
        public int NodeId { get; set; }
        public Guid Id { get; set; }
        public Types Type { get; set; }
    }
}
