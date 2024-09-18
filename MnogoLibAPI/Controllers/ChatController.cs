using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _chatService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Chat chatService)
        {
            await _chatService.Create(chatService);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Chat authorStatus)
        {
            await _chatService.Update(authorStatus);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.Delete(id);
            return Ok();
        }
    }
}