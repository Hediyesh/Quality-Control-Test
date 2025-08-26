using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetAllQualityControlEntries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQualityControlEntry
{
    public class GetQualityControlEntryQuery: IRequest<GetQualityControlEntriesDto>
    {
        public int qle {  get; set; }   
    }
}
