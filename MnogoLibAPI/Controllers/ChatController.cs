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

        /// <summary>
        /// Получение информации о всех чатах
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<ChatController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatService.GetAll());
        }

        /// <summary>
        /// Получение информации о чате по id
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
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<ChatController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _chatService.GetById(id));
        }


        /// <summary>
        /// Создание нового чата
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "idChat": 0,
        ///        "idOwner": 0,
        ///        "nameChat": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="author">Автор</param>
        /// <returns></returns>

        // POST api/<ChatController>

        [HttpPost]
        public async Task<IActionResult> Add(Chat chatService)
        {
            await _chatService.Create(chatService);
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
        /// <param name="author">Автор</param>
        /// <returns></returns>

        // PUT api/<ChatController>

        [HttpPut]
        public async Task<IActionResult> Update(Chat authorStatus)
        {
            await _chatService.Update(authorStatus);
            return Ok();
        }

        /// <summary>
        /// Удаление чата
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
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<ChatController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _chatService.Delete(id);
            return Ok();
        }
    }
}