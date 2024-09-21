using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using MnogoLibAPI.Contracts.User;

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
            var Dto = await _userService.GetAll();

            return Ok(Dto.Adapt<List<GetUserRequest>>());
        }

        /// <summary>
        /// Получение информации о пользователе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<UsersController>


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _userService.GetById(id);
            return Ok(Dto.Adapt<GetUserRequest>());
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
        public async Task<IActionResult> Add(CreateUserRequest user)
        {
            var Dto = user.Adapt<User>();
            await _userService.Create(Dto);
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
        public async Task<IActionResult> Update(GetUserRequest user)
        {
            var Dto = user.Adapt<User>();
            await _userService.Update(Dto);
            return Ok();
        }


        /// <summary>
        /// Удаление пользователя
        /// </summary>
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