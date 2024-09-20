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


        /// <summary>
        /// Получение информации о всех оценках
        /// </summary>
        /// <returns></returns>

        // GET api/<RateController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _rateService.GetAll());
        }

        /// <summary>
        /// Получение информации об оценке по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<RateController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _rateService.GetById(id));
        }


        /// <summary>
        /// Создание новой оценки
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idUser": 0,
        ///       "idMaterial": 0,
        ///       "valueRate": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="rate">Оценка</param>
        /// <returns></returns>

        // POST api/<RateController>

        [HttpPost]
        public async Task<IActionResult> Add(Rate rate)
        {
            await _rateService.Create(rate);
            return Ok();
        }


        /// <summary>
        /// Изменение информации об оценке
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idRate": 0,
        ///       "idUser": 0,
        ///       "idMaterial": 0,
        ///       "valueRate": 0,
        ///       "createdTime": "2024-09-20T18:20:33.320Z",
        ///       "lastUpdateTime": "2024-09-20T18:20:33.320Z",
        ///       "deletedTime": "2024-09-20T18:20:33.320Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="rate">Оценка</param>
        /// <returns></returns>

        // PUT api/<RateController>

        [HttpPut]
        public async Task<IActionResult> Update(Rate rate)
        {
            await _rateService.Update(rate);
            return Ok();
        }

        /// <summary>
        /// Удаление оценки
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<RateController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _rateService.Delete(id);
            return Ok();
        }
    }
}