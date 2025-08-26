using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Queries.GetDataForEditOrAddML
{
    public class GetDataForEditOrAddMLQuery :IRequest<GetDataForEditOrAddMLDto>
    {
        public int? MLId { get; set; }
    }
}
