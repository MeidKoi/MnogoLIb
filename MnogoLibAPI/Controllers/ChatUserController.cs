using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
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

        /// <summary>
        /// Получение информации о всех пользователях чатов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<ChatUserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatUserService.GetAll());
        }

        /// <summary>
        /// Получение информации о пользователях в чате по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     Get /Todo
        ///     {
        ///        "idChat": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="idChat">IDChat</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // GET api/<ChatUserController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idChat, int idUser)
        {
            return Ok(await _chatUserService.GetById(idChat, idUser));
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
        ///        "idChat": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="chatUser">Пользователь чата</param>
        /// <returns></returns>

        // POST api/<ChatUserController>

        [HttpPost]
        public async Task<IActionResult> Add(ChatUser chatUser)
        {
            await _chatUserService.Create(chatUser);
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
        public async Task<IActionResult> Update(ChatUser chatUser)
        {
            await _chatUserService.Update(chatUser);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя чата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     DELETE /Todo
        ///     {
        ///         id: 1
        ///     }
        ///
        /// </remarks>
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