using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Commands.DeleteQualityControlEntry
{
    public class DeleteQualityControlEntryCommand: IRequest<ResultDto>
    {
        public int qcId { get; set; }
    }
}
