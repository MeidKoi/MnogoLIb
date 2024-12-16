using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Contracts.Author;
using MnogoLibAPI.Contracts.User;
using MnogoLibAPI.Controllers;

namespace BackendApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        /// <summary>
        /// Получение информации о всех авторах
        /// </summary>
        /// <returns></returns>

        // GET api/<AuthorController>

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _authorService.GetAll();

            return Ok(Dto.Adapt<List<GetAuthorRequest>>());
        }

        /// <summary>
        /// Получение информации о авторе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<AuthorController>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _authorService.GetById(id);
            return Ok(Dto.Adapt<GetAuthorRequest>());
        }

        /// <summary>
        /// Создание нового автора
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "nameAuthor": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="author">Автор</param>
        /// <returns></returns>

        // POST api/<AuthorController>

        [Authorize(2, 3)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateAuthorRequest author)
        {
            var Dto = author.Adapt<Author>();
            await _authorService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о авторе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idAuthor": 0,
        ///       "nameAuthor": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="author">Автор</param>
        /// <returns></returns>

        // PUT api/<AuthorController>

        [Authorize(2, 3)]
        [HttpPut]
        public async Task<IActionResult> Update(GetAuthorRequest author)
        {
            var Dto = author.Adapt<Author>();
            await _authorService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление автора
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<AuthorController>
        [Authorize(2, 3)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return Ok();
        }
    }
}