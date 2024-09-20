using Domain.Interfaces;
using Domain.Models;
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

        /// <summary>
        /// Получение информации о всех сообщениях
        /// </summary>
        /// <returns></returns>

        // GET api/<MessageUserController>


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _materialService.GetAll());
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
            return Ok(await _materialService.GetById(id));
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
        ///       "idMessageStatus": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Пользователь</param>
        /// <returns></returns>

        // POST api/<MessageUserController>

        [HttpPost]
        public async Task<IActionResult> Add(MessagesUser material)
        {
            await _materialService.Create(material);
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
        /// <param name="material">Пользователь</param>
        /// <returns></returns>

        // PUT api/<MessageUserController>

        [HttpPut]
        public async Task<IActionResult> Update(MessagesUser material)
        {
            await _materialService.Update(material);
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