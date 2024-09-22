using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.CommentRate;
using MnogoLibAPI.Contracts.User;
using System;
using System.Xml.Linq;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentRateController : ControllerBase
    {
        private ICommentRateService _commentRateService;
        public CommentRateController(ICommentRateService commentRateService)
        {
            _commentRateService = commentRateService;
        }

        /// <summary>
        /// Получение информации о всех оценках комментариев
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<CommentRateController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _commentRateService.GetAll();

            return Ok(Dto.Adapt<List<GetCommentRateRequest>>());
        }

        /// <summary>
        /// Получение информации об оценках комментариев по id
        /// </summary>
        /// <param name="idComment">IDChat</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // GET api/<CommentRateController>

        [HttpGet("{idComment}/{idUser}")]
        public async Task<IActionResult> GetById(int idUser, int idComment)
        {
            var Dto = await _commentRateService.GetById(idUser, idComment);
            return Ok(Dto.Adapt<GetCommentRateRequest>());
        }

        /// <summary>
        /// Добовление новой оценки комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "idUser": 0,
        ///        "idChat": 0,
        ///        "value": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="commentRate">Пользователь чата</param>
        /// <returns></returns>

        // POST api/<CommentRateController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentRateRequest commentRate)
        {
            var Dto = commentRate.Adapt<CommentRate>();
            await _commentRateService.Create(Dto);
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
        ///       "idUser": 0,
        ///       "idComment": 0,
        ///       "value": 0,
        ///       "createdTime": "2024-09-19T15:18:41.474Z",
        ///       "lastUpdateTime": "2024-09-19T15:18:41.474Z",
        ///       "deletedTime": "2024-09-19T15:18:41.474Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="commentRate">Оценка</param>
        /// <returns></returns>

        // PUT api/<CommentRateController>
        [HttpPut]
        public async Task<IActionResult> Update(GetCommentRateRequest commentRate)
        {
            var Dto = commentRate.Adapt<CommentRate>();
            await _commentRateService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление оценки комментария
        /// </summary>
        /// <param name="idComment">IDChat</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // DELETE api/<CommentRateController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int idUser, int idComment)
        {
            await _commentRateService.Delete(idUser, idComment);
            return Ok();
        }
    }
}