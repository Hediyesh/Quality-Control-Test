using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.EditCategory
{
    public class EditCategoryCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int CompanyId { get; set; }

    }
}
