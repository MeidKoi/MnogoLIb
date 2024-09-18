using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using File = Domain.Models.File;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fileService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _fileService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(File file)
        {
            await _fileService.Create(file);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(File file)
        {
            await _fileService.Update(file);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.Delete(id);
            return Ok();
        }
    }
}