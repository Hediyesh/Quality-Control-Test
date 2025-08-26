using ControlService.ControlApplication.Services.Products.Queries.GetAllProducts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.Products.Queries.GetProduct
{
    public class GetProductQuery: IRequest<GetProductsDto>
    {
        public int ProductId { get; set; }
    }
}
