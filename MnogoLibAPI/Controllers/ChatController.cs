using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Contracts.Chat;
using MnogoLibAPI.Contracts.User;
using MnogoLibAPI.Controllers;
using System;

namespace BackendApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : BaseController
    {
        private IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        /// <summary>
        /// Получение информации о всех чатах
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<ChatController>

        [Authorize(3)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _chatService.GetAll();

            return Ok(Dto.Adapt<List<GetChatRequest>>());
        }

        /// <summary>
        /// Получение информации о чате по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<ChatController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _chatService.GetById(id);
            if (Dto.IdOwner != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            return Ok(Dto.Adapt<GetChatRequest>());
        }


        /// <summary>
        /// Создание нового чата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "idOwner": 0,
        ///        "nameChat": "string",
        ///        "lastUpdatedBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="chat">Чат</param>
        /// <returns></returns>

        // POST api/<ChatController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateChatRequest chat)
        {
            var Dto = chat.Adapt<Chat>();
            if (Dto.IdOwner != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            Dto.LastUpdateBy = Dto.IdOwner;
            await _chatService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о чате
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///         "idChat": 0,
        ///         "idOwner": 0,
        ///         "nameChat": "string",
        ///         "createdTime": "2024-09-19T14:34:41.968Z",
        ///         "lastUpdateBy": 0,
        ///         "lastUpdateTime": "2024-09-19T14:34:41.969Z",
        ///         "deletedBy": 0,
        ///         "deletedTime": "2024-09-19T14:34:41.969Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="chat">Чат</param>
        /// <returns></returns>

        // PUT api/<ChatController>

        [Authorize(3)]
        [HttpPut]
        public async Task<IActionResult> Update(GetChatRequest chat)
        {
            var Dto = chat.Adapt<Chat>();
            await _chatService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление чата
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<ChatController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var Dto = await _chatService.GetById(id);
            if (Dto.IdOwner != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _chatService.Delete(id);
            return Ok();
        }
    }
}