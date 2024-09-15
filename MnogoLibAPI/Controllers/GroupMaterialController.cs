using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMaterialController : ControllerBase
    {
        private IGroupMaterialService _groupMaterialService;
        public GroupMaterialController(IGroupMaterialService materialService)
        {
            _groupMaterialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupMaterialService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupMaterialService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(GroupMaterial material)
        {
            await _groupMaterialService.Create(material);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GroupMaterial material)
        {
            await _groupMaterialService.Update(material);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMaterialService.Delete(id);
            return Ok();
        }
    }
}