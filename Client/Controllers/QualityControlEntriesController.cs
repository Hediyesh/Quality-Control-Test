using Client.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class QualityControlEntriesController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public QualityControlEntriesController(IHttpClientFactory factory, IHttpContextAccessor accessor)
    {
        _httpClient = factory.CreateClient("GatewayClient");
        _contextAccessor = accessor;
    }

    private void AttachToken()
    {
        var token = _contextAccessor.HttpContext?.Session.GetString("JWToken");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }

    // ================== لیست همه ==================
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AttachToken();
        var response = await _httpClient.GetAsync("/api/control/qualitycontrolentries");

        if (!response.IsSuccessStatusCode)
            return Unauthorized("دسترسی غیرمجاز یا توکن نامعتبر است");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<List<QualityControlEntriesViewModel>>(json);
        return View(result);
    }

    // ================== جزئیات ==================
    //[HttpGet("{id}")]
    //public async Task<IActionResult> Details(int id)
    //{
    //    AttachToken();
    //    var response = await _httpClient.GetAsync($"/api/control/qualitycontrolentries/{id}");

    //    if (!response.IsSuccessStatusCode)
    //        return NotFound();

    //    var json = await response.Content.ReadAsStringAsync();
    //    var result = JsonConvert.DeserializeObject<QualityControlEntriesViewModel>(json);
    //    return View(result);
    //}

    // ================== ایجاد ==================
    [HttpPost]
    public async Task<IActionResult> AddQualityControlEntry([FromBody] AddQualityControlEntryViewModel model)
    {
        AttachToken();
        var response = await _httpClient.PostAsJsonAsync("/api/control/qualitycontrolentries", model);
        var json = await response.Content.ReadAsStringAsync();
        return Content(json, "text/plain; charset=utf-8");

    }

    // ================== ویرایش ==================
    [HttpPut]
    public async Task<IActionResult> EditQualityControlEntry(int id, [FromBody] UpdateQualityControlEntryViewModel dto)
    {
        AttachToken();
        var response = await _httpClient.PutAsJsonAsync($"/api/control/qualitycontrolentries?id={id}", dto);
        var json = await response.Content.ReadAsStringAsync();
        return Content(json, "text/plain; charset=utf-8");

    }

    // ================== حذف ==================
    [HttpDelete]
    public async Task<IActionResult> DeleteQualityControlEntry(int id)
    {
        AttachToken();
        var response = await _httpClient.DeleteAsync($"/api/control/qualitycontrolentries?id={id}");
        var json = await response.Content.ReadAsStringAsync();
        return Content(json, "text/plain; charset=utf-8");
    }

    // ================== اکشن‌های کمکی ==================
    // برای گرفتن DropDown ها در Create یا Edit
    [HttpGet]
    public async Task<IActionResult> EditOrCreateQCEPartial(int? id)
    {
        AttachToken();
        var response = await _httpClient.GetAsync($"/api/control/qualitycontrolentries/EditOrCreateQCEPartial?id={id}");

        if (!response.IsSuccessStatusCode)
            return BadRequest("خطا در دریافت داده‌ها");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetDropDownForEditOrAddQCEViewModel>(json);
        return PartialView("EditOrCreateQCEPartial", result);
    }

    // برای آپدیت محصولات و ماشین‌ها بر اساس شرکت
    [HttpGet]
    public async Task<IActionResult> UpdateQCEMachinesCategoriesByCompany(int id)
    {
        AttachToken();
        var response = await _httpClient.GetAsync($"/api/control/qualitycontrolentries/UpdateQCEMachinesCategoriesByCompany?id={id}");

        if (!response.IsSuccessStatusCode)
            return BadRequest("خطا در دریافت ماشین‌ها و محصولات");

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetQCEProductsMachinesByCompanyViewModel>(json);
        Console.WriteLine(result);
        return Json(result);
    }
}