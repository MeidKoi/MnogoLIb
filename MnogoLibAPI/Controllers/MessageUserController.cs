using BusinessLogic.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageUserController : ControllerBase
    {
        private IMessageUserService _materialService;
        public MessageUserController(IMessageUserService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _materialService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _materialService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MessagesUser material)
        {
            await _materialService.Create(material);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MessagesUser material)
        {
            await _materialService.Update(material);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.Delete(id);
            return Ok();
        }
    }
}