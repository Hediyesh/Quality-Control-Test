using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Commands.AddProduct
{
    public class AddProductCommand: IRequest<ResultDto>
    {
        public string ProductName { get; set; }
        public int CategoryId {  get; set; }
        public int CompanyId { get; set; }
        public List<int>? Machines { get; set; }

    }
}
