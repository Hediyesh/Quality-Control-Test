using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public CategoryDto? Category { get; set; }
        public ProductDto? Product { get; set; }
        public MachineDto? Machine { get; set; }
        public CompanyDto? Company { get; set; }

        public static ResultDto Success(
    string? message = null,
    CategoryDto? categoryDto = null,
    ProductDto? productDto = null,
    MachineDto? machineDto = null,
    CompanyDto? companyDto = null)
        {
            return new ResultDto
            {
                IsSuccess = true,
                Message = message,
                Category = categoryDto,
                Product = productDto,
                Machine = machineDto,
                Company = companyDto
            };
        }

        public static ResultDto Fail(string message)
        {
            return new ResultDto { IsSuccess = false, Message = message };
        }
    }
}
