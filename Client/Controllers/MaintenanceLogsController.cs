//using Control.Application.Services.MaintenanceLogs.Commands.AddMaintenanceLogs;
//using Control.Application.Services.MaintenanceLogs.Commands.DeleteMaintenanceLogs;
//using Control.Application.Services.MaintenanceLogs.Commands.EditMaintenanceLogs;
//using Control.Application.Services.MaintenanceLogs.Queries.GetAllMaintenanceLogs;
//using Control.Application.Services.MaintenanceLogs.Queries.GetDataForEditOrAddML;
//using Control.Application.Services.MaintenanceLogs.Queries.GetMaintenanceLog;
//using Control.Application.Services.MaintenanceLogs.Queries.GetMLMachinesByCompany;
//using Control.Application.Services.QualityControlEntries.Queries.GetDropDownForEditOrAddQCE;
//using Control.Application.Services.QualityControlEntries.Queries.GetQCEProductsMachinesByCompany;
//using Endpoint.Control.Dtos;
//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace ControlEndPoint.Controllers
//{
//    //[Authorize(Roles = "admin")]
//    public class MaintenanceLogsController : Controller
//    {
//        private readonly IMediator _mediator;
//        public MaintenanceLogsController(IMediator mediator)
//        {
//            _mediator = mediator;
//        }
//        [HttpGet]
//        public async Task<IActionResult> GetAllMaintenanceLogs()
//        {
//            var mls = await _mediator.Send(new GetAllMaintenanceLogsQuery());
//            return View(mls);
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetMaintenanceLog(int id)
//        {
//            var ml = await _mediator.Send(new GetMaintenanceLogQuery { mlId = id });
//            return View(ml);
//        }
//        [HttpPost]
//        public async Task<IActionResult> AddMaintenanceLog([FromBody] AddMaintenanceLogCommand command)
//        {
//            if (command == null)
//            {
//                return BadRequest("داده خالی است!");
//            }
//            var result = await _mediator.Send(command);

//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        //[HttpPut("{id}")]
//        [AcceptVerbs("PUT")]
//        public async Task<IActionResult> EditMaintenanceLog(int id, [FromBody] UpdateMaintenanceLogDto dto)
//        {
//            if (dto == null)
//            {
//                return BadRequest("داده خالی است!");
//            }
//            var result = await _mediator.Send(new EditMaintenanceLogCommand
//            {
//                CompanyId = dto.CompanyId,
//                Description = dto.Description,
//                HoursSpent = dto.HoursSpent,
//                MachineId = dto.MachineId,
//                MaintenanceDate = dto.MaintenanceDate,
//                MaintenanceId = dto.MaintenanceId,
//                MaintenanceLogStatusId = dto.MaintenanceLogStatusId,
//                mlId = id,
//                NextScheduleDate = dto.NextScheduleDate,
//                PersonId = dto.PersonId
//            });

//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        //[HttpDelete("{id}")]
//        [AcceptVerbs("DELETE")]
//        public async Task<IActionResult> DeleteMaintenanceLog(int id)
//        {
//            var result = await _mediator.Send(new DeleteMaintenanceLogCommand { mlId = id });
//            if (!result.IsSuccess)
//                return BadRequest(result.Message);

//            return Ok(result.Message);
//        }
//        [HttpGet]
//        public async Task<IActionResult> EditOrCreateMLPartial(int? id)
//        {
//            var ml = await _mediator.Send(new GetDataForEditOrAddMLQuery { MLId = id });
//            return PartialView("EditOrCreateMLPartialView", ml);
//        }
//        [HttpGet]
//        public async Task<IActionResult> UpdateMLMachinesByCompany(int id)
//        {
//            var data = await _mediator.Send(new GetMLMachinesByCompanyQuery { companyId = id });
//            return Json(new
//            {
//                machines = data.Select(m => new { machineId = m.MachineId, machineName = m.MachineName })
//            });
//        }
//    }
//}
