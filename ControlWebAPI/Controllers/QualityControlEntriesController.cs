using ControlApplication.Services.QualityControlEntries.Queries.GetDailyCounts;
using ControlService.ControlApplication.Services;
using ControlService.ControlApplication.Services.QualityControlEntries.Commands.AddQualityControlEntry;
using ControlService.ControlApplication.Services.QualityControlEntries.Commands.DeleteQualityControlEntry;
using ControlService.ControlApplication.Services.QualityControlEntries.Commands.EditQualityControlEntry;
using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetAllQualityControlEntries;
using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetDropDownForEditOrAddQCE;
using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQCEProductsMachinesByCompany;
using ControlService.ControlApplication.Services.QualityControlEntries.Queries.GetQualityControlEntry;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlEndPoint.Areas.Admin.Controllers
{
    [ApiController]
    [Route("api/control/[controller]")]
    public class QualityControlEntriesController : Controller
    {
        private readonly IMediator _mediator;
        public QualityControlEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQualityControlEntries()
        {
            var qcs = await _mediator.Send(new GetAllQualityControlEntriesQuery());
            return Ok(qcs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQualityControlEntry(int id)
        {
            var qc = await _mediator.Send(new GetQualityControlEntryQuery { qle = id });
            return Ok(qc);
        }
        [HttpPost]
        public async Task<IActionResult> AddQualityControlEntry([FromBody] AddQualityControlEntryCommand command)
        {
            if (command == null)
            {
                return BadRequest("داده خالی است!");
            }
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [AcceptVerbs("PUT")]
        public async Task<IActionResult> EditQualityControlEntry(int id, [FromBody] UpdateQualityControlEntryDto dto)
        {
            if (dto == null)
            {
                return BadRequest("داده خالی است!");
            }
            var result = await _mediator.Send(new EditQualityControlEntryCommand
            {
                qcId = id,
                PersonId = dto.PersonId,
                MachineId = dto.MachineId,
                BatchId = dto.BatchId,
                CompanyId = dto.CompanyId,
                CorrectiveAction = dto.CorrectiveAction,
                DefectDescription = dto.DefectDescription,
                DefectId = dto.DefectId,
                InspectionDate = dto.InspectionDate,
                ProductId = dto.ProductId,
                QualityDefective = dto.QualityDefective,
                QuantityInspected = dto.QuantityInspected,
                RootCause = dto.RootCause,
                SeverityId = dto.SeverityId
            });

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [AcceptVerbs("DELETE")]
        public async Task<IActionResult> DeleteQualityControlEntry(int id)
        {
            var result = await _mediator.Send(new DeleteQualityControlEntryCommand { qcId = id });
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpGet("EditOrCreateQCEPartial")]
        public async Task<IActionResult> EditOrCreateQCEPartial(int? id)
        {
            var qce = await _mediator.Send(new GetDropDownForEditOrAddQCEQuery { QCEId = id });
            return Ok(qce);
        }
        [HttpGet("UpdateQCEMachinesCategoriesByCompany")]
        public async Task<IActionResult> UpdateQCEMachinesCategoriesByCompany(int id)
        {
            var data = await _mediator.Send(new GetQCEProductsMachinesByCompanyQuery { companyId = id });
            return Ok(new
            {
                products = data.Products?.Select(c => new { productId = c.ProductId, productName = c.ProductName }),
                machines = data.Machines?.Select(m => new { machineId = m.MachineId, machineName = m.MachineName })
            });
        }
        [HttpGet("DailyCounts")]
        public async Task<IActionResult> GetDailyCounts()
        {
            var result = await _mediator.Send(new GetDailyCountsQuery());
            return Ok(result);
        }

    }
}
