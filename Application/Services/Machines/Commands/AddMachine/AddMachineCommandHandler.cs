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
    public class AddMachineCommandHandler : IRequestHandler<AddMachineCommand, MachineDto>
    {
        private readonly IDataBaseContext _db;
        public AddMachineCommandHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<MachineDto> Handle(AddMachineCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.MachineName))
                return new MachineDto { resultMessage= "لطفا نام دستگاه را مشخص کنید" };
            var company = await _db.Companies.Where(w => w.CompanyId == request.CompanyId).FirstOrDefaultAsync();
            if (company == null)
                return new MachineDto { resultMessage= "لطفا شرکت را انتخاب کنید" };
            var oldMachine = await _db.Machines.Where(w => w.CompanyId == request.CompanyId && w.MachineName == request.MachineName).FirstOrDefaultAsync();
            if (oldMachine != null)
                return new MachineDto { resultMessage= "این دستگاه از قبل در این شرکت اضافه شده است" };
            var machine = new Machine()
            {
                MachineName = request.MachineName,
                CompanyId = request.CompanyId,
            };
            await _db.Machines.AddAsync(machine);
            await _db.SaveChangesAsync();
            return new MachineDto
            {
                MachineName = request.MachineName,
                CompanyId = request.CompanyId,
                Id = machine.MachineId,
                resultMessage = "اطلاعات با موفقیت ثبت شد"
            };
            //return ResultDto.Success(, machineDto: new MachineDto()
            //{
            //    MachineName = machine.MachineName, 
            //    CompanyId = machine.CompanyId,
            //    Id = request.CompanyId,
            //    CompanyName = company.CompanyName,
            //});
        }
    }
}
