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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _chatUserService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idPayment, int idUser)
        {
            return Ok(await _chatUserService.GetById(idPayment, idUser));
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentUser chatUserService)
        {
            await _chatUserService.Create(chatUserService);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PaymentUser chatUserService)
        {
            await _chatUserService.Update(chatUserService);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idPayment, int idUser)
        {
            await _chatUserService.Delete(idPayment, idUser);
            return Ok();
        }
    }
}