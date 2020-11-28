using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication4.Dtos;
using WebApplication4.Models.Shared;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    [Produces("application/json")]
    public class FieldController : Controller
    {
        private readonly IFieldService _fieldService;
        private readonly IHistoryService _historyservice;
        private IMemoryCache _cache;
        public FieldController(IFieldService fieldService, IHistoryService historyService, IMemoryCache cache)
        {
            _cache = cache;
            _fieldService = fieldService;
            _historyservice = historyService;
        }

        [HttpGet("field/{id}")]
        public async Task<IActionResult> GetFieldAsync(int id)
        {
            var fieldItem = await _fieldService.GetFieldByIdAsync(id);
            if (fieldItem == null)
                return NotFound(new ErrorMessage($"Item with id: {id} does not exist"));

            return Ok(fieldItem);
        }

        [HttpGet("fields")]
        public async Task<IActionResult> GetFieldsAsync()
        {
            var result = await _fieldService.GetFieldsAsync();

            return Ok(result);
        }

        [HttpGet("fields/{customerId}")]
        public async Task<IActionResult> GetFieldValuesByCustomerAsync(int customerId)
        {
            var result = await _fieldService.GetFieldsByCustomerIdAsync(customerId);

            return Ok(result);
        }

        [HttpPost("field")]
        public async Task<IActionResult> CreateFieldAsync([FromBody] CreateFieldDto fieldDto)
        {
            await _fieldService.CreateFieldAsync(fieldDto, Request.HttpContext.RequestAborted);

            return Ok(new { Success = true });
        }

        [HttpPut("field")]
        public async Task<IActionResult> UpdateFieldAsync([FromBody] UpdateFieldDto fieldDto)
        {
            await _fieldService.UpdateFieldAsync(fieldDto, Request.HttpContext.RequestAborted);

            return Ok(new { Success = true });
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistoryAsync()
        {
            var result = await _historyservice.GetHistoryAsync();

            return Ok(result);
        }        
    }
}
