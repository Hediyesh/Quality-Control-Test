using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.DeleteMaintenanceLogs
{
    public class DeleteMaintenanceLogHandler: IRequestHandler<DeleteMaintenanceLogCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public DeleteMaintenanceLogHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public async Task<ResultDto> Handle(DeleteMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
            var ml = _db.MaintenanceLogs.Where(w => w.MLId == request.mlId).FirstOrDefault();
            if (ml == null)
            {
                return ResultDto.Fail("چنین نگهداری و تعمیرات پیشگیرانه‌ای وجود ندارد!");
            }
            _db.MaintenanceLogs.Remove(ml);
            await _db.SaveChangesAsync();
            return ResultDto.Success("با موفقیت حذف شد.");
        }
    }
}
