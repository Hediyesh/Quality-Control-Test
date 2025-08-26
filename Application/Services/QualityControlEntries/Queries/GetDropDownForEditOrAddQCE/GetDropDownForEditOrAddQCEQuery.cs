using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetDropDownForEditOrAddQCE
{
    public class GetDropDownForEditOrAddQCEQuery : IRequest<GetDropDownForEditOrAddQCEDto>
    {
        public int? QCEId { get; set; }
    }
}
