using ControlApplication.Services.Categories.Commands.DeleteCategory;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Commands.DeleteMachine
{
    public class DeleteMachineCommandHandler : IRequestHandler<DeleteMachineCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public DeleteMachineCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(DeleteMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = await _db.Machines.Where(w => w.MachineId == request.Id).FirstOrDefaultAsync();
            if (machine == null)
                return ResultDto.Fail("چنین دستگاهی وجود ندارد");
            var logs = await _db.MaintenanceLogs.Where(w => w.MachineId == request.Id).ToListAsync();
            var qces = await _db.QualityControlEntries.Where(w => w.MachineId == request.Id).ToListAsync();
            if (logs.Count > 0 || qces.Count > 0)
                return ResultDto.Fail("این دستگاه به علت داشتن اطلاعات در جداول دیگر نمی تواند حذف شود");
            _db.Machines.Remove(machine);
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت حذف شد");
        }
    }
}
