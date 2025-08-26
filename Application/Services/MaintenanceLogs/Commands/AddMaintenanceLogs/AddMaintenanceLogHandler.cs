using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MediatR;

namespace ControlService.ControlApplication.Services.MaintenanceLogs.Commands.AddMaintenanceLogs
{
    public class AddMaintenanceLogHandler: IRequestHandler<AddMaintenanceLogCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public AddMaintenanceLogHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public async Task<ResultDto> Handle(AddMaintenanceLogCommand request, CancellationToken cancellationToken)
        {
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
            var person = ""; //* _db.Persons.Where(w=> w.PersonId == request.PersonId).SingleOrDefault();
            int? pid = null;
            if (person != null) {
                pid = request.PersonId;
            }
            var ml = new MaintenanceLog
            {
                CompanyId = request.CompanyId,
                MachineId = request.MachineId,
                PersonId = pid,
                MaintenanceDate = request.MaintenanceDate,
                HoursSpent = request.HoursSpent,
                Description = request.Description,
                MaintenanceLogStatusId = request.MaintenanceLogStatusId,
                MaintenanceId = request.MaintenanceId,
                NextScheduleDate = request.NextScheduleDate,
            };
            await _db.MaintenanceLogs.AddAsync(ml);
            await _db.SaveChangesAsync();
            return ResultDto.Success("با موفقیت اضافه شد.");
        }
    }
}
