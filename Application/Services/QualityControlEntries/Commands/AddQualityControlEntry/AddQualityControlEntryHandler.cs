using ControlApplication.Common.Notifications;
using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;
using ControlService.ControlApplication.Interfaces.Contexts;
using ControlService.ControlDomain.Entities;
using MassTransit.Mediator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Commands.AddQualityControlEntry
{
    public class AddQualityControlEntryHandler : IRequestHandler<AddQualityControlEntryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        private readonly MediatR.IMediator _mediator;
        private readonly INotificationService _notificationService;

        public AddQualityControlEntryHandler(
            IDataBaseContext db,
            MediatR.IMediator mediator,
            INotificationService notificationService)
        {
            _db = db;
            _mediator = mediator;
            _notificationService = notificationService;
        }
        //private readonly IDataBaseContext _db;
        //public AddQualityControlEntryHandler(IDataBaseContext db)
        //{
        //    _db = db;
        //}

        public async Task<ResultDto> Handle(AddQualityControlEntryCommand request, CancellationToken cancellationToken)
        {
            if (_db.Companies.Where(s => s.CompanyId == request.CompanyId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین شرکتی وجود ندارد!");
            }
            if (request.CompanyId == 0)
            {
                return ResultDto.Fail("لطفا شرکت را انتخاب کنید!");
            }
            if (_db.Products.Where(s => s.ProductId == request.ProductId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین محصولی وجود ندارد!");
            }
            if (request.ProductId == 0)
            {
                return ResultDto.Fail("لطفا محصول را انتخاب کنید!");
            }
            if (_db.Defects.Where(s => s.DefectId == request.DefectId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین نوع عیبی وجود ندارد!");
            }
            if (request.DefectId == 0)
            {
                return ResultDto.Fail("لطفا نوع عیب را مشخص کنید!");
            }
            if (_db.Severities.Where(s => s.SeverityId == request.SeverityId).SingleOrDefault() == null)
            {
                return ResultDto.Fail("چنین شدت عیبی وجود ندارد!");
            }
            if (request.SeverityId == 0)
            {
                return ResultDto.Fail("لطفا شدت عیب را مشخص کنید!");
            }
            if (_db.Batchs.Where(s => s.BatchId == request.BatchId).SingleOrDefault() == null)
            {   
                return ResultDto.Fail("چنین سری ساختی وجود ندارد!");
            }
            if (request.BatchId == 0)
            {
                return ResultDto.Fail("لطفا سری ساخت را مشخص کنید!");
            }
            if (request.DefectDescription == "")
            {
                return ResultDto.Fail("لطفا عیب را شرح دهید!");
            }
            if (request.QuantityInspected == 0)
            {
                return ResultDto.Fail("لطفا تعداد واحد بازرسی شده را مشخص کنید!");
            }
            if (request.QualityDefective == 0)
            {
                return ResultDto.Fail("لطفا تعداد واحد معیوب یافت شده را مشخص کنید!");
            }
            if (request.DefectDescription == "")
            {
                return ResultDto.Fail("لطفا عیب را شرح دهید!");
            }
            if (request.QuantityInspected == 0)
            {
                return ResultDto.Fail("لطفا تعداد واحد بازرسی شده را مشخص کنید!");
            }
            if (request.QualityDefective == 0)
            {
                return ResultDto.Fail("لطفا تعداد واحد معیوب یافت شده را مشخص کنید!");
            }
            if (request.InspectionDate == default)
            {
                return ResultDto.Fail("تاریخ وارد شده نامعتبر است!");
            }
            //var date = request.InspectionDate;
            // اصلاح ساعت‌های خراب شده بر اثر timezone
            //date = date.AddDays(1).Date;
            var person = "";// * _db.Persons.Where(w => w.PersonId == request.PersonId).SingleOrDefault();
            int? pid = null;
            if (person != null)
            {
                pid = request.PersonId;
            }
            //var date = DateTime.Now;
            var qc = new QualityControlEntry {
                BatchId = request.BatchId,
                DefectId = request.DefectId,
                CompanyId = request.CompanyId,
                CorrectiveAction = request.CorrectiveAction,
                DefectDescription = request.DefectDescription,
                InspectionDate = request.InspectionDate,
                MachineId = request.MachineId,
                ProductId = request.ProductId,
                QualityDefective = request.QualityDefective,
                QuantityInspected = request.QuantityInspected,
                RootCause = request.RootCause,
                SeverityId = request.SeverityId,
                PersonId = pid,
                AddedDateTime = DateTime.Now
            };
            await _db.QualityControlEntries.AddAsync(qc);
            await _db.SaveChangesAsync();
            // 2. گرفتن لیست تمام روزها + تعداد رکوردها
            var dailyCounts = await _mediator.Send(new GetDailyCountsQuery());

            // 3. ارسال لیست به کلاینت‌ها از طریق SignalR
            await _notificationService.SendDailyCountsUpdateAsync(dailyCounts);
            return ResultDto.Success("با موفقیت افزوده شد.");
        }
    }
}
