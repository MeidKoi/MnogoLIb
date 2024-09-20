using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        /// <summary>
        /// Получение информации о всех картах
        /// </summary>
        /// <returns></returns>

        // GET api/<PaymentController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _paymentService.GetAll());
        }


        /// <summary>
        /// Получение информации о карте по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<PaymentController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _paymentService.GetById(id));
        }

        /// <summary>
        /// Создание новой карты
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "cardNumber": "string",
        ///       "cvv": "string",
        ///       "expressionDate": "2024-09-20T17:59:37.667Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="payment">Карта</param>
        /// <returns></returns>

        // POST api/<PaymentController>

        [HttpPost]
        public async Task<IActionResult> Add(Payment payment)
        {
            await _paymentService.Create(payment);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о карте
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idPayment": 0,
        ///       "cardNumber": "string",
        ///       "cvv": "string",
        ///       "expressionDate": "2024-09-20T18:00:15.835Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="payment">Карта</param>
        /// <returns></returns>

        // PUT api/<PaymentController>

        [HttpPut]
        public async Task<IActionResult> Update(Payment payment)
        {
            await _paymentService.Update(payment);
            return Ok();
        }

        /// <summary>
        /// Удаление карты
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<PaymentController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.Delete(id);
            return Ok();
        }
    }
}