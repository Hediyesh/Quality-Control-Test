using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
    }
}
