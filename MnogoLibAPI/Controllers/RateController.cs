using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Contracts.Rate;
using MnogoLibAPI.Contracts.User;
using MnogoLibAPI.Controllers;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateController : BaseController
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _rateService.GetAll();

            return Ok(Dto.Adapt<List<GetRateRequest>>());
        }

        /// <summary>
        /// Получение информации об оценке по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<RateController>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _rateService.GetById(id);
            return Ok(Dto.Adapt<GetUserRequest>());
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
        public async Task<IActionResult> Add(CreateRateRequest rate)
        {
            var Dto = rate.Adapt<Rate>();
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _rateService.Create(Dto);
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
        public async Task<IActionResult> Update(GetRateRequest rate)
        {
            var Dto = rate.Adapt<Rate>();
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _rateService.Update(Dto);
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
            var Dto = await _rateService.GetById(id);
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _rateService.Delete(id);
            return Ok();
        }
    }
}