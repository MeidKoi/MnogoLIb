using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _commentRateService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idComment, int idUser)
        {
            return Ok(await _commentRateService.GetById(idComment, idUser));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentRate commentRateService)
        {
            await _commentRateService.Create(commentRateService);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CommentRate commentRateService)
        {
            await _commentRateService.Update(commentRateService);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idComment, int idUser)
        {
            await _commentRateService.Delete(idComment, idUser);
            return Ok();
        }
    }
}