using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Backend.Application.Interfaces.Services;
using PhoneDirectory.Backend.Application.Models.Phones;
using PhoneDirectory.Backend.Controllers.Base;

namespace PhoneDirectory.Backend.Controllers;

public class PhonesController : BaseController
{
    private readonly IPhoneAppService _phoneAppService;

    public PhonesController(IPhoneAppService phoneAppService)
    {
        _phoneAppService = phoneAppService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _phoneAppService.GetByUserIdAsync(GetUserId()));
    
    [HttpPost]
    public async Task<IActionResult> AddPhone([FromBody] AddPhoneModel model) =>
        Ok(await _phoneAppService.AddAsync(model, GetUserId()));
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePhone(int id, [FromBody] UpdatePhoneModel model) =>
        Ok(await _phoneAppService.UpdateAsync(model, id, GetUserId()));
    
    [HttpDelete("{id:int}")]
    public async Task UpdatePhone(int id) =>
        await _phoneAppService.DeleteAsync(id);
}