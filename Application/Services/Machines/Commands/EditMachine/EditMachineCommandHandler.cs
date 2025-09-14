using ControlApplication.Services.Categories.Commands.EditCategory;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Commands.EditMachine
{
    public class EditMachineCommandHandler : IRequestHandler<EditMachineCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public EditMachineCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditMachineCommand request, CancellationToken cancellationToken)
        {
            var machine = await _db.Machines.Where(w => w.MachineId == request.Id).FirstOrDefaultAsync();
            if (machine == null)
                return ResultDto.Fail("چنین دستگاهی وجود ندارد");
            if (string.IsNullOrEmpty(request.MachineName))
                return ResultDto.Fail("لطفا نام دستگاه را مشخص کنید");
            var company = await _db.Companies.Where(w => w.CompanyId == request.CompanyId).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید");
            var oldMachine = await _db.Machines.Where(w => w.CompanyId == request.CompanyId && w.MachineName == request.MachineName
            && w.MachineId != request.Id).FirstOrDefaultAsync();
            if (oldMachine != null)
                return ResultDto.Fail("این دستگاه از قبل در این شرکت اضافه شده است");
            machine.MachineName = request.MachineName;
            machine.CompanyId = request.CompanyId;
            await _db.SaveChangesAsync(cancellationToken);
            return ResultDto.Success("اطلاعات با موفقیت ویرایش شد");
        }
    }
}
