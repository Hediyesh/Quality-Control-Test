using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Queries.GetAllProducts
{
    public class GetAllProductQuery : IRequest<List<GetProductsDto>>
    {
    }
    public class GetProductMachineDto
    {
        public string Name { get; set; }
        public int id { get; set; }
    }
}
