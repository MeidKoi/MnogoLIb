using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _comment;
        public CommentController(ICommentService comment)
        {
            _comment = comment;
        }

        /// <summary>
        /// Получение информации о всех комментариях
        /// </summary>
        /// <returns></returns>

        // GET api/<CommentController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _comment.GetAll());
        }

        /// <summary>
        /// Получение информации о комментарии по id
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
        /// <param name="idComment">ID</param>
        /// <returns></returns>

        // GET api/<CommentController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idComment)
        {
            return Ok(await _comment.GetById(idComment));
        }

        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "idComment": 0,
        ///         "textComment": "string",
        ///         "idUser": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="comment">Комментарий</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(Comment comment)
        {
            await _comment.Create(comment);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о комментарие
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idComment": 0,
        ///       "textComment": "string",
        ///       "idUser": 0,
        ///       "createdTime": "2024-09-19T15:04:44.267Z",
        ///       "lastUpdateTime": "2024-09-19T15:04:44.267Z",
        ///       "deletedTime": "2024-09-19T15:04:44.267Z",
        ///     }
        ///
        /// </remarks>
        /// <param name="comment">Комментарий</param>
        /// <returns></returns>

        // PUT api/<CommentController>

        [HttpPut]
        public async Task<IActionResult> Update(Comment comment)
        {
            await _comment.Update(comment);
            return Ok();
        }


        /// <summary>
        /// Удаление комментария    
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
        /// <param name="idComment">ID</param>
        /// <returns></returns>

        // DELETE api/<CommentController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int idComment)
        {
            await _comment.Delete(idComment);
            return Ok();
        }
    }
}