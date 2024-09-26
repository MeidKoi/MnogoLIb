using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.Material;
using MnogoLibAPI.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        /// <summary>
        /// Получение информации о всех материалах
        /// </summary>
        /// <returns></returns>

        // GET api/<MaterialController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _materialService.GetAll();

            return Ok(Dto.Adapt<List<GetMaterialRequest>>());
        }

        /// <summary>
        /// Получение информации о материале по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<MaterialController>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _materialService.GetById(id);
            return Ok(Dto.Adapt<GetMaterialRequest>());
        }

        /// <summary>
        /// Создание нового материале
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "nameMaterial": "string",
        ///       "descriptionMaterial": "string",
        ///       "idCategory": 0,
        ///       "idAuthorStatus": 0,
        ///       "idAuthor": 0,
        ///       "createdBy": 0,
        ///       "fileIcon": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Материал</param>
        /// <returns></returns>

        // POST api/<MaterialController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateMaterialRequest material)
        {
            var Dto = material.Adapt<Material>();
            Dto.LastUpdateBy = Dto.CreatedBy;
            await _materialService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о материале
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idMaterial": 0,
        ///       "nameMaterial": "string",
        ///       "descriptionMaterial": "string",
        ///       "idCategory": 0,
        ///       "idAuthorStatus": 0,
        ///       "idAuthor": 0,
        ///       "createdBy": 0,
        ///       "createdTime": "2024-09-21T12:18:21.215Z",
        ///       "lastUpdateBy": 0,
        ///       "lastUpdateTime": "2024-09-21T12:18:21.215Z",
        ///       "deletedBy": 0,
        ///       "deletedTime": "2024-09-21T12:18:21.215Z",
        ///       "fileIcon": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Материал</param>
        /// <returns></returns>

        // PUT api/<MaterialController>

        [HttpPut]
        public async Task<IActionResult> Update(GetMaterialRequest material)
        {
            var Dto = material.Adapt<Material>();
            await _materialService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление материала
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<MaterialController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _materialService.Delete(id);
            return Ok();
        }
    }
}