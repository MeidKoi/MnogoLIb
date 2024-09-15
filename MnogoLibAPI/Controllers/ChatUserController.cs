using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatUserController : ControllerBase
    {
        private IChatUserService _chatUserService;
        public ChatUserController(IChatUserService chatUserService)
        {
            _chatUserService = chatUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatUserService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idChat, int idUser)
        {
            return Ok(await _chatUserService.GetById(idChat, idUser));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChatUser chatUserService)
        {
            await _chatUserService.Create(chatUserService);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ChatUser chatUserService)
        {
            await _chatUserService.Update(chatUserService);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idChat, int idUser)
        {
            await _chatUserService.Delete(idChat, idUser);
            return Ok();
        }
    }
}