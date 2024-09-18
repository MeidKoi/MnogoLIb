using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private IRateService _rateService;
        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rateService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rateService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Rate rate)
        {
            await _rateService.Create(rate);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Rate rate)
        {
            await _rateService.Update(rate);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _rateService.Delete(id);
            return Ok();
        }
    }
}