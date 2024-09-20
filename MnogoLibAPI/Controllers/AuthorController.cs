using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        /// <summary>
        /// Получение информации о авторе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<AuthorController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _authorService.GetById(id));
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

        [HttpPost]
        public async Task<IActionResult> Add(Author author)
        {
            await _authorService.Create(author);
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


        [HttpPut]
        public async Task<IActionResult> Update(Author author)
        {
            await _authorService.Update(author);
            return Ok();
        }

        /// <summary>
        /// Удаление автора
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<AuthorController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.Delete(id);
            return Ok();
        }
    }
}