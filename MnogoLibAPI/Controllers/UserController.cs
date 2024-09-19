using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Получение информации о всех пользователях
        /// </summary>
        /// <returns></returns>

        // GET api/<UsersController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }

        /// <summary>
        /// Получение информации о пользователе по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     Get /Todo
        ///     {
        ///        "id" : 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UsersController>


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _userService.GetById(id));
        }


        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "email" : "email@gmail.com"
        ///        "passwordUser" : "!Pa$$word123@",
        ///        "nicknameUser": "string",
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>

        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idUser": 1,
        ///       "emailUser": "string",
        ///       "passwordUser": "string",
        ///       "nicknameUser": "string",
        ///       "idRole": 1,
        ///       "createdTime": "2024-09-19T14:05:14.947Z",
        ///       "lastUpdateBy": 1,
        ///       "lastUpdateTime": "2024-09-19T14:05:14.947Z",
        ///       "deletedBy": 1,
        ///       "deletedTime": "2024-09-19T14:05:14.947Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UsersController>


        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);
            return Ok();
        }


        /// <summary>
        /// Удаление пользователя
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

        // DELETE api/<UsersController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}