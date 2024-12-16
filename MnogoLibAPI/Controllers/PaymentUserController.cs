using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Contracts.PaymentUser;
using MnogoLibAPI.Contracts.User;
using MnogoLibAPI.Controllers;
using System;

namespace BackendApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentUserController : BaseController
    {
        private IPaymentUserService _paymentUser;
        public PaymentUserController(IPaymentUserService chatUserService)
        {
            _paymentUser = chatUserService;
        }

        /// <summary>
        /// Получение информации о всех пользователях чатов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<PaymentUserController>
        [Authorize(3)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _paymentUser.GetAll();

            return Ok(Dto.Adapt<List<GetPaymentUserRequest>>());
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
            var Dto = await _paymentUser.GetById(idPayment, idUser);
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            return Ok(Dto.Adapt<GetPaymentUserRequest>());
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
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // POST api/<PaymentUserController>

        [HttpPost]
        public async Task<IActionResult> Add(CreatePaymentUserRequest paymentUser)
        {
            var Dto = paymentUser.Adapt<PaymentUser>();
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _paymentUser.Create(Dto);
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
        /// <param name="paymentUser">Карты пользователя</param>
        /// <returns></returns>

        // PUT api/<PaymentUserController>

        [HttpPut]
        public async Task<IActionResult> Update(PaymentUser paymentUser)
        {
            var Dto = paymentUser.Adapt<PaymentUser>();
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _paymentUser.Update(Dto);
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
            var Dto = await _paymentUser.GetById(idPayment, idUser);
            if (Dto.IdUser != User.IdUser && User.IdRole != 3)
                return Unauthorized(new { message = "Unauthorized" });
            await _paymentUser.Delete(idPayment, idUser);
            return Ok();
        }
    }
}