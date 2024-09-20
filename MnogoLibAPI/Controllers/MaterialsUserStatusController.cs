using Domain.Interfaces;
using BusinessLogic.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsUserStatusController : ControllerBase
    {
        private IMaterialsUserStatusService _materialsUserStatusService;
        public MaterialsUserStatusController(IMaterialsUserStatusService materialsUserStatusService)
        {
            _materialsUserStatusService = materialsUserStatusService;
        }


        /// <summary>
        /// Получение информации о всех пользователских статусах материлов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<MaterialsUserStatusController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _materialsUserStatusService.GetAll());
        }

        /// <summary>
        /// Получение информации об пользовательских статусах материала по id
        /// </summary>
        /// <param name="idMaterial">IDMaterial</param>
        /// <param name="idUser">IDUser</param>
        /// <param name="idUserStatus">IDUserStatus</param>
        /// <returns></returns>

        // GET api/<MaterialsUserStatusController>

        [HttpGet("{idMaterial}/{idUser}/{idUserStatus}")]
        public async Task<IActionResult> GetById(int idMaterial, int idUser, int idUserStatus)
        {
            return Ok(await _materialsUserStatusService.GetById(idMaterial, idUser, idUserStatus));
        }

        /// <summary>
        /// Добовление нового пользовательского статуса материала
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idMaterial": 0,
        ///       "idUser": 0,
        ///       "idUserStatus": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="materialsUserStatusService">Пользовательский статус</param>
        /// <returns></returns>

        // POST api/<MaterialsUserStatusController>

        [HttpPost]
        public async Task<IActionResult> Add(MaterialsUserStatus materialsUserStatusService)
        {
            await _materialsUserStatusService.Create(materialsUserStatusService);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользовательском статусе материала
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idMaterial": 0,
        ///       "idUser": 0,
        ///       "idUserStatus": 0,
        ///       "createdTime": "2024-09-20T17:46:52.710Z",
        ///       "lastUpdateTime": "2024-09-20T17:46:52.710Z",
        ///       "deletedTime": "2024-09-20T17:46:52.710Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="materialsUserStatusService">Пользовательский статус</param>
        /// <returns></returns>

        // PUT api/<MaterialsUserStatusController>

        [HttpPut]
        public async Task<IActionResult> Update(MaterialsUserStatus materialsUserStatusService)
        {
            await _materialsUserStatusService.Update(materialsUserStatusService);
            return Ok();
        }

        /// <summary>
        /// Удаление файла материала
        /// </summary>
        /// <param name="idMaterial">IDMaterial</param>
        /// <param name="idUser">IDUser</param>
        /// <param name="idUserStatus">IDUserStatus</param>
        /// <returns></returns>

        // DELETE api/<MaterialsUserStatusController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int idMaterial, int idUser, int idUserStatus)
        {
            await _materialsUserStatusService.Delete(idMaterial, idUser, idUserStatus);
            return Ok();
        }
    }
}