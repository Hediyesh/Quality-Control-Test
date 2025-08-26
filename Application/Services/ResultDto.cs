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

        public static ResultDto Success(string? message = null)
        {
            return new ResultDto { IsSuccess = true, Message = message };
        }

        public static ResultDto Fail(string message)
        {
            return new ResultDto { IsSuccess = false, Message = message };
        }
    }
}
