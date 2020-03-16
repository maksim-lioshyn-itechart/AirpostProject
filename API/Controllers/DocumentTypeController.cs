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
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;
        private readonly ILogger<DocumentTypeController> _logger;

        public DocumentTypeController(
            IDocumentTypeService documentTypeService,
            ILogger<DocumentTypeController> logger
            )
        {
            _documentTypeService = documentTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<DocumentTypeViewModel>> Get()
        {
            return (await _documentTypeService.GetAll()).Select(ur => ur.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentTypeViewModel>> Get(Guid id)
        {
            var user = (await _documentTypeService.GetById(id)).ToViewModel();
            if (user == null)
            {
                _logger.LogInformation($"DocumentType id = {id} not found.");
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPut]
        public async Task<ActionResult<DocumentTypeViewModel>> Update(DocumentTypeViewModel documentType)
        {
            var response = await _documentTypeService.Update(documentType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Updated)
            {
                _logger.LogError($"DocumentType {documentType.Name} not Updated.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<DocumentTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpPost]
        public async Task<ActionResult<DocumentTypeViewModel>> Post(DocumentTypeViewModel documentType)
        {
            var response = await _documentTypeService.Create(documentType.ToModel());
            if (response != BusinessLogic.Enums.StatusCode.Created)
            {
                _logger.LogError($"DocumentType {documentType.Name} not Created.");
            }

            return response == BusinessLogic.Enums.StatusCode.Created
                ? (ActionResult<DocumentTypeViewModel>)Ok()
                : Conflict();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<DocumentTypeViewModel>> Delete(Guid id)
        {
            var documentType = await _documentTypeService.GetById(id);
            if (documentType == null)
            {
                _logger.LogInformation($"DocumentType id = {id} not found.");
                return NotFound();
            }

            await _documentTypeService.Delete(documentType);
            return Ok(documentType);
        }
    }
}
