using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.CompanyCategoriesMachines.GetCompanyCategoriesMachines
{
    public class GetCompanyCategoriesMachinesQuery: IRequest<GetCompanyCategoriesMachinesDto>
    {
        public int companyId { get; set; }
    }
}
