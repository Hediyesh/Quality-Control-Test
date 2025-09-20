using ControlApplication.Services.Categories.Commands.AddCategory;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlApplication.Services;
using ControlService.ControlDomain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlApplication.Services.Machines.Commands.AddMachine
{
    public class AddMachineCommandHandler : IRequestHandler<AddMachineCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public AddMachineCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(AddMachineCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.MachineName))
                return ResultDto.Fail("لطفا نام دستگاه را مشخص کنید");
            var company = await _db.Companies.Where(w => w.CompanyId == request.CompanyId).FirstOrDefaultAsync();
            if (company == null)
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید");
            var oldMachine = await _db.Machines.Where(w => w.CompanyId == request.CompanyId && w.MachineName == request.MachineName).FirstOrDefaultAsync();
            if (oldMachine != null)
                return ResultDto.Fail("این دستگاه از قبل در این شرکت اضافه شده است");
            var machine = new Machine()
            {
                MachineName = request.MachineName,
                CompanyId = request.CompanyId,
            };
            await _db.Machines.AddAsync(machine);
            await _db.SaveChangesAsync();
            return ResultDto.Success("اطلاعات با موفقیت ثبت شد", machineDto: new MachineDto()
            {
                MachineName = machine.MachineName, 
                CompanyId = machine.CompanyId,
                Id = request.CompanyId,
                CompanyName = company.CompanyName,
            });
        }
    }
}
