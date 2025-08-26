using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand: IRequest<ResultDto>
    {
        public int ProductId { get; set; }
    }
}
