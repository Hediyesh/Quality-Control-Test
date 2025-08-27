using ControlApplication.Common.Notifications;
using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;
using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Commands.DeleteQualityControlEntry
{
    public class DeleteQualityControlEntryHandler: IRequestHandler<DeleteQualityControlEntryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        private readonly IMediator _mediator;
        private readonly INotificationService _notificationService;

        public DeleteQualityControlEntryHandler(
            IDataBaseContext db,
            IMediator mediator,
            INotificationService notificationService)
        {
            _db = db;
            _mediator = mediator;
            _notificationService = notificationService;
        }
        //public readonly IDataBaseContext _db;
        //public DeleteQualityControlEntryHandler(IDataBaseContext db)
        //{
        //    _db = db;
        //}
        public async Task<ResultDto> Handle(DeleteQualityControlEntryCommand request, CancellationToken cancellationToken)
        {
            var q = _db.QualityControlEntries.Where(w => w.QCEId == request.qcId).FirstOrDefault();
            if (q == null)
            {
                return ResultDto.Fail("در لیست کنترل کیفیت موجود نمی‌باشد!");
            }
            _db.QualityControlEntries.Remove(q);
            await _db.SaveChangesAsync();
            // 2. گرفتن لیست تمام روزها + تعداد رکوردها
            var dailyCounts = await _mediator.Send(new GetDailyCountsQuery());

            // 3. ارسال لیست به کلاینت‌ها از طریق SignalR
            await _notificationService.SendDailyCountsUpdateAsync(dailyCounts);

            return ResultDto.Success("با موفقیت حذف شد.");
        }
    }
}
