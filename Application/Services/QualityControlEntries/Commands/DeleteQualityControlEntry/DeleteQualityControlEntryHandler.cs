using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Commands.DeleteQualityControlEntry
{
    public class DeleteQualityControlEntryHandler: IRequestHandler<DeleteQualityControlEntryCommand, ResultDto>
    {
        public readonly IDataBaseContext _db;
        public DeleteQualityControlEntryHandler(IDataBaseContext db)
        {
            _db = db;
        }
        public async Task<ResultDto> Handle(DeleteQualityControlEntryCommand request, CancellationToken cancellationToken)
        {
            var q = _db.QualityControlEntries.Where(w => w.QCEId == request.qcId).FirstOrDefault();
            if (q == null)
            {
                return ResultDto.Fail("در لیست کنترل کیفیت موجود نمی‌باشد!");
            }
            _db.QualityControlEntries.Remove(q);
            await _db.SaveChangesAsync();
            return ResultDto.Success("با موفقیت حذف شد.");
        }
    }
}
