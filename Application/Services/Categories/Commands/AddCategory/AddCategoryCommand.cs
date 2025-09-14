using ControlService.ControlApplication.Services;
using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<ResultDto>
    {
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }
    }
}
