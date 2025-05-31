using HrApp.DomainEntities.DTO.Request;
using HrApp.DomainEntities.DTO.Response;
using HrApp.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HrAppWebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DocumentTemplateController : ControllerBase
    {
        private readonly IDocumentTemplateService _service;

        public DocumentTemplateController(IDocumentTemplateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentTemplateResponseDto>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentTemplateResponseDto>> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("name/{templateName}")]
        public async Task<ActionResult<DocumentTemplateResponseDto>> GetByName(string templateName)
        {
            var result = await _service.GetByNameAsync(templateName);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("type/{templateType}")]
        public async Task<ActionResult<IEnumerable<DocumentTemplateResponseDto>>> GetByType(string templateType)
        {
            return Ok(await _service.GetByTypeAsync(templateType));
        }

        [HttpGet("{id}/content")]
        public async Task<ActionResult<string>> GetTemplateContent(Guid id)
        {
            var content = await _service.GetTemplateContentAsync(id);
            return content == null ? NotFound() : Ok(content);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentTemplateResponseDto>> Create([FromBody] DocumentTemplateRequestDto dto)
        {
            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.TemplateID }, created);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DocumentTemplateRequestDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
