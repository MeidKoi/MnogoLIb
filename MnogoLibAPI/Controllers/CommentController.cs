﻿using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.Comment;
using MnogoLibAPI.Contracts.User;
using MnogoLibAPI.Controllers;
using System;
using AuthorizeAttribute = BusinessLogic.Authorization.AuthorizeAttribute;

namespace BackendApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _comment.GetAll();

            return Ok(Dto.Adapt<List<GetCommentRequest>>());
        }

        /// <summary>
        /// Получение информации о комментарии по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<CommentController>

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _comment.GetById(id);
            return Ok(Dto.Adapt<GetCommentRequest>());
        }

        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///         "idUser": 0,
        ///         "textComment": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="comment">Комментарий</param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Add(CreateCommentRequest comment)
        {
            if (comment.IdUser != User.IdUser && User.IdRole != 3 && string.IsNullOrEmpty(comment.TextComment))
                return Unauthorized(new { message = "Unauthorized" });
            var Dto = comment.Adapt<Comment>();
            await _comment.Create(Dto);
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
        public async Task<IActionResult> Update(GetCommentRequest comment)
        {
            if (comment.IdUser != User.IdUser && User.IdRole != 3 && string.IsNullOrEmpty(comment.TextComment))
                return Unauthorized(new { message = "Unauthorized" });
            var Dto = comment.Adapt<Comment>();
            await _comment.Update(Dto);
            return Ok();
        }


        /// <summary>
        /// Удаление комментария    
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<CommentController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await _comment.GetById(id);
            if (comment.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _comment.Delete(id);
            return Ok();
        }
    }
}