using ControlService.ControlApplication.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<ResultDto>
    {
        public int Id { get; set; }
    }
}
