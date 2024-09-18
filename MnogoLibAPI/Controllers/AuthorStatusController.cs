using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorStatusController : ControllerBase
    {
        private IAuthorStatusService _authorStatusService;
        public AuthorStatusController(IAuthorStatusService authorStatusService)
        {
            _authorStatusService = authorStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorStatusService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _authorStatusService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuthorStatus authorStatus)
        {
            await _authorStatusService.Create(authorStatus);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(AuthorStatus authorStatus)
        {
            await _authorStatusService.Update(authorStatus);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorStatusService.Delete(id);
            return Ok();
        }
    }
}