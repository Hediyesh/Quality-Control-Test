using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.UserCompanyCategoryMachine.GetUserCompanyCategoryMachine
{
    public class GetUserCompanyCategoryMachineQuery : IRequest<GetUserCompanyCategoryMachineDto>
    {
        public string UserName { get; set; }
        public int? ProductId { get; set; }
    }
}
