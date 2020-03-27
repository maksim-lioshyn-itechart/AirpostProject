using API.Models;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.Mappers.CommonMapper;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(
            IDocumentService documentService,
            ILogger<DocumentController> logger
            )
        {
            _documentService = documentService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentViewModel>> Get()
        {
            return (await _documentService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentViewModel>> Get(Guid id)
        {
            var user = (await _documentService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"Document id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<DocumentViewModel>> Update(DocumentViewModel document)
        {
            var response = await _documentService.Update(document.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"Document {document.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<DocumentViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<DocumentViewModel>> Post(DocumentViewModel document)
        {
            var response = await _documentService.Create(document.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"Document {document.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<DocumentViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DocumentViewModel>> Delete(Guid id)
        {
            var document = await _documentService.GetById(id);
            if (document == null)
            {
                _logger.LogInformation($"Document id = {id} not found.");
                return NotFound();
            }

            await _documentService.Delete(document);
            return Ok(document);
        }
    }
}
