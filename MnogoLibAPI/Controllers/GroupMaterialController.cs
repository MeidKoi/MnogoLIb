using BusinessLogic.Authorization;
using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Contracts.GroupMaterial;
using MnogoLibAPI.Controllers;

namespace BackendApi.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _groupMaterialService.GetAll();

            return Ok(Dto.Adapt<List<GetGroupMaterialRequest>>());
        }


        /// <summary>
        /// Получение информации о группе по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<GroupMaterialController>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _groupMaterialService.GetById(id);
            return Ok(Dto.Adapt<GetGroupMaterialRequest>());
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
        /// <param name="group">Группа</param>
        /// <returns></returns>

        // POST api/<GroupMaterialController>
        [Authorize(2, 3)]
        [HttpPost]
        public async Task<IActionResult> Add(CreateGroupMaterialRequest group)
        {
            var Dto = group.Adapt<GroupMaterial>();
            await _groupMaterialService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о группе материалов
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
        /// <param name="group">Группа</param>
        /// <returns></returns>

        // PUT api/<GroupMaterialController>
        [Authorize(2, 3)]
        [HttpPut]
        public async Task<IActionResult> Update(GetGroupMaterialRequest group)
        {
            var Dto = group.Adapt<GroupMaterial>();
            await _groupMaterialService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление групп материалов
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<GroupMaterialController>
        [Authorize(2, 3)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _groupMaterialService.Delete(id);
            return Ok();
        }
    }
}