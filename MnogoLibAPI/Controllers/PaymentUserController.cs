using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentUserController : ControllerBase
    {
        private IPaymentUserService _chatUserService;
        public PaymentUserController(IPaymentUserService chatUserService)
        {
            _chatUserService = chatUserService;
        }

        /// <summary>
        /// Получение информации о всех пользователях чатов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<PaymentUserController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatUserService.GetAll());
        }


        /// <summary>
        /// Получение информации о картах пользователя по id
        /// </summary>
        /// <param name="idPayment">IDPayment</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // GET api/<PaymentUserController>

        [HttpGet("{idPayment}/{idUser}")]
        public async Task<IActionResult> GetById(int idPayment, int idUser)
        {
            return Ok(await _chatUserService.GetById(idPayment, idUser));
        }

        /// <summary>
        /// Добовление новых карт пользователю
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idPayment": 0,
        ///       "idUser": 0,
        ///       "isActive": true
        ///     }
        ///
        /// </remarks>
        /// <param name="chatUserService">Карты пользователя</param>
        /// <returns></returns>

        // POST api/<PaymentUserController>

        [HttpPost]
        public async Task<IActionResult> Add(PaymentUser chatUserService)
        {
            await _chatUserService.Create(chatUserService);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о картах пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idPayment": 0,
        ///       "idUser": 0,
        ///       "isActive": true
        ///     }
        ///
        /// </remarks>
        /// <param name="chatUserService">Карты пользователя</param>
        /// <returns></returns>

        // PUT api/<PaymentUserController>

        [HttpPut]
        public async Task<IActionResult> Update(PaymentUser chatUserService)
        {
            await _chatUserService.Update(chatUserService);
            return Ok();
        }

        /// <summary>
        /// Удаление карт пользователя
        /// </summary>
        /// <param name="idPayment">IDPayment</param>
        /// <param name="idUser">IDUser</param>
        /// <returns></returns>

        // DELETE api/<PaymentUserController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int idPayment, int idUser)
        {
            await _chatUserService.Delete(idPayment, idUser);
            return Ok();
        }
    }
}