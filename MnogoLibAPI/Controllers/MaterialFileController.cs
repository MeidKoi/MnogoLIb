using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialFileController : ControllerBase
    {
        private IMaterialFileService _materialFileService;
        public MaterialFileController(IMaterialFileService materialFileService)
        {
            _materialFileService = materialFileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _materialFileService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idMaterial, int idFile)
        {
            return Ok(await _materialFileService.GetById(idMaterial, idFile));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MaterialFile material)
        {
            await _materialFileService.Create(material);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaterialFile material)
        {
            await _materialFileService.Update(material);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idMaterial, int idFile)
        {
            await _materialFileService.Delete(idMaterial, idFile);
            return Ok();
        }
    }
}