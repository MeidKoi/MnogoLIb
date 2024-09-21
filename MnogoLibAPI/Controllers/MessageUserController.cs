using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.MessageUser;
using Mapster;
using MnogoLibAPI.Contracts.User;

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

        /// <summary>
        /// Получение информации о всех сообщениях
        /// </summary>
        /// <returns></returns>

        // GET api/<MessageUserController>


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _materialService.GetAll();

            return Ok(Dto.Adapt<List<GetMessageUserRequest>>());
        }


        /// <summary>
        /// Получение информации о сообщении по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<MessageUserController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _materialService.GetById(id);
            return Ok(Dto.Adapt<GetMessageUserRequest>());
        }

        /// <summary>
        /// Создание нового сообщения
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idUser": 0,
        ///       "idChat": 0,
        ///       "idMessageStatus": 0,
        ///       "textMessage": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="message">Пользователь</param>
        /// <returns></returns>

        // POST api/<MessageUserController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateMessageUserRequest message)
        {
            var Dto = message.Adapt<MessagesUser>();
            await _materialService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о сообщении
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idMessage": 0,
        ///       "idUser": 0,
        ///       "idChat": 0,
        ///       "deliverDate": "2024-09-20T17:52:42.696Z",
        ///       "idMessageStatus": 0,
        ///       "textMessage": "string",
        ///       "createdTime": "2024-09-20T17:52:42.696Z",
        ///       "lastUpdateTime": "2024-09-20T17:52:42.696Z",
        ///       "deletedBy": 0,
        ///       "deletedTime": "2024-09-20T17:52:42.696Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="message">Пользователь</param>
        /// <returns></returns>

        // PUT api/<MessageUserController>

        [HttpPut]
        public async Task<IActionResult> Update(GetMessageUserRequest message)
        {
            var Dto = message.Adapt<MessagesUser>();
            await _materialService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<MessageUserController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.Delete(id);
            return Ok();
        }
    }
}