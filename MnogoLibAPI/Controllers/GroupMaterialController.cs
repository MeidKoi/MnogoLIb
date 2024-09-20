using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMaterialController : ControllerBase
    {
        private IGroupMaterialService _groupMaterialService;
        public GroupMaterialController(IGroupMaterialService materialService)
        {
            _groupMaterialService = materialService;
        }

        /// <summary>
        /// Получение информации о всех группах
        /// </summary>
        /// <returns></returns>

        // GET api/<GroupMaterialController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupMaterialService.GetAll());
        }


        /// <summary>
        /// Получение информации о группе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<GroupMaterialController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _groupMaterialService.GetById(id));
        }


        /// <summary>
        /// Создание новой группы
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "nameGroup": "string",
        ///       "descriptionGroup": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Группа</param>
        /// <returns></returns>

        // POST api/<GroupMaterialController>

        [HttpPost]
        public async Task<IActionResult> Add(GroupMaterial material)
        {
            await _groupMaterialService.Create(material);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о пользователе
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idGroup": 0,
        ///       "nameGroup": "string",
        ///       "descriptionGroup": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Группа</param>
        /// <returns></returns>

        // PUT api/<GroupMaterialController>

        [HttpPut]
        public async Task<IActionResult> Update(GroupMaterial material)
        {
            await _groupMaterialService.Update(material);
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<GroupMaterialController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMaterialService.Delete(id);
            return Ok();
        }
    }
}