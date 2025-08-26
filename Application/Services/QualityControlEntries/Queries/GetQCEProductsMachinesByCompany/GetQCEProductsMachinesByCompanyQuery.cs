using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQCEProductsMachinesByCompany
{
    public class GetQCEProductsMachinesByCompanyQuery: IRequest<GetQCEProductsMachinesByCompanyDto>
    {
        public int companyId { get; set; }
    }
}
