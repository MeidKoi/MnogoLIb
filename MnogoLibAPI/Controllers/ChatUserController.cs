using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.ChatUser;
using MnogoLibAPI.Contracts.User;
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

        /// <summary>
        /// Получение информации о всех пользователях чатов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<ChatUserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _chatUserService.GetAll();

            return Ok(Dto.Adapt<List<GetChatUserRequest>>());
        }

        /// <summary>
        /// Получение информации о пользователях в чате по id
        /// </summary>
        /// <param name="idChat">IDChat</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // GET api/<ChatUserController>

        [HttpGet("{idChat}/{idUser}")]
        public async Task<IActionResult> GetById(int idChat, int idUser)
        {
            var Dto = await _chatUserService.GetById(idChat, idUser);
            return Ok(Dto.Adapt<GetChatUserRequest>());
        }

        /// <summary>
        /// Добовление нового пользователя в чат
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "idUser": 0,
        ///        "idChat": 0,
        ///        "createdBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="chatUser">Пользователь чата</param>
        /// <returns></returns>

        // POST api/<ChatUserController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateChatUserRequest chatUser)
        {
            var Dto = chatUser.Adapt<ChatUser>();
            await _chatUserService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе чата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///         "idUser": 0,
        ///         "idChat": 0,
        ///         "createdBy": 0,
        ///         "createdTime": "2024-09-19T14:50:41.116Z",
        ///         "deletedBy": 0,
        ///         "deletedTime": "2024-09-19T14:50:41.116Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="chatUser">Пользователь чата</param>
        /// <returns></returns>

        // PUT api/<ChatUserController>

        [HttpPut]
        public async Task<IActionResult> Update(GetChatUserRequest chatUser)
        {
            var Dto = chatUser.Adapt<ChatUser>();
            await _chatUserService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя чата
        /// </summary>
        /// <param name="idChat">IDChat</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // DELETE api/<ChatUserController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int idChat, int idUser)
        {
            await _chatUserService.Delete(idChat, idUser);
            return Ok();
        }
    }
}