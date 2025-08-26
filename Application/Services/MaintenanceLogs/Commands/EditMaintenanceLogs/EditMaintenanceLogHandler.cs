using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.EditMaintenanceLogs
{
    public class EditMaintenanceLogHandler : IRequestHandler<EditMaintenanceLogCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public EditMaintenanceLogHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
            var ml = _db.MaintenanceLogs.Where(w => w.MLId == request.mlId).FirstOrDefault();
            if (ml == null) {
                return ResultDto.Fail("چنین نگهداری و تعمیرات پیشگیرانه‌ای وجود ندارد!");
            }
            if (_db.Companies.Where(s => s.CompanyId == request.CompanyId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین شرکتی وجود ندارد!");
            }
            if (request.CompanyId == 0)
            {
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید!");
            }
            if (_db.MaintenanceTypes.Where(s => s.MaintenanceId == request.MaintenanceId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("نوع نگهداری وجود ندارد!");
            }
            if (request.MaintenanceId == 0)
            {
                return ResultDto.Fail("لطفا نوع نگهداری را انتخاب کنید!");
            }
            if (_db.MaintenanceLogStatuses.Where(s => s.StatusId == request.MaintenanceLogStatusId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین وضعیتی وجود ندارد!");
            }
            if (request.MaintenanceLogStatusId == 0)
            {
                return ResultDto.Fail("لطفا وضعیت را انتخاب کنید!");
            }
            if (_db.Machines.Where(s => s.MachineId == request.MachineId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین دستگاهی وجود ندارد!");
            }
            if (request.MachineId == 0)
            {
                return ResultDto.Fail("لطفا دستگاه را انتخاب کنید!");
            }
            if (request.Description == "")
            {
                return ResultDto.Fail("لطفا کار را شرح دهید!");
            }
            if (request.HoursSpent == 0)
            {
                return ResultDto.Fail("لطفا مدت زمان صرف شده برای نگهداری را وارد نمایید!");
            }
            if (request.MaintenanceDate == default)
            {
                return ResultDto.Fail("لطفا تاریخ و زمان نگهداری را مشخص کنید!");
            }
            var person = ""; // * _db.Persons.Where(w => w.PersonId == request.PersonId).SingleOrDefault();
            int? pid = null;
            if (person != null)
            {
                pid = request.PersonId;
            }
            else
            {
                pid = null;
            }
            ml.CompanyId = request.CompanyId;
            ml.MachineId = request.MachineId;
            ml.PersonId = pid;
            ml.MaintenanceDate = request.MaintenanceDate;
            ml.HoursSpent = request.HoursSpent;
            ml.Description = request.Description;
            ml.MaintenanceLogStatusId = request.MaintenanceLogStatusId;
            ml.MaintenanceId = request.MaintenanceId;
            ml.NextScheduleDate = request.NextScheduleDate;
            await _db.SaveChangesAsync();
            return ResultDto.Success("با موفقیت ویرایش شد.");
        }
    }
}
