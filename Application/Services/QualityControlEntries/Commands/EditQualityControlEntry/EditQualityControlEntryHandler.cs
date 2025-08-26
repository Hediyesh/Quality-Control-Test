using ControlService.ControlApplication.Interfaces.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlService.ControlApplication.Services.QualityControlEntries.Commands.EditQualityControlEntry
{
    public class EditQualityControlEntryHandler : IRequestHandler<EditQualityControlEntryCommand, ResultDto>
    {
        private readonly IDataBaseContext _db;
        public EditQualityControlEntryHandler(IDataBaseContext db)
        {
            _db = db;
        }

        public async Task<ResultDto> Handle(EditQualityControlEntryCommand request, CancellationToken cancellationToken)
        {
            var q = _db.QualityControlEntries.Where(w => w.QCEId == request.qcId).FirstOrDefault();
            if (q == null)
            {
                return ResultDto.Fail("در لیست کنترل کیفیت موجود نمی‌باشد!");
            }
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
            if (request.InspectionDate == default)
            {
                return ResultDto.Fail("تاریخ وارد شده نامعتبر است!");
            }
            //var date = request.InspectionDate;
            // اصلاح ساعت‌های خراب شده بر اثر timezone
            //date = date.AddDays(1).Date;
            var person = ""; //* _db.Persons.Where(w => w.PersonId == request.PersonId).SingleOrDefault();
            int? pid = null;
            if (person != null)
            {
                pid = request.PersonId;
            }
            q.BatchId = request.BatchId;
            q.MachineId = request.MachineId;
            q.DefectId = request.DefectId;
            q.CompanyId = request.CompanyId;
            q.SeverityId = request.SeverityId;
            q.CorrectiveAction = request.CorrectiveAction;
            q.DefectDescription = request.DefectDescription;
            q.InspectionDate = request.InspectionDate;
            q.QualityDefective = request.QualityDefective;
            q.QuantityInspected = request.QuantityInspected;
            q.RootCause = request.RootCause;
            q.PersonId = 1;//* pid;
            q.ProductId = request.ProductId;
            await _db.SaveChangesAsync();
            return ResultDto.Success("با موفقیت ویرایش شد.");
        }
    }
}
