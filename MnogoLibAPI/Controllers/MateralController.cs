using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _materialService.GetAll());
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
            return Ok(await _materialService.GetById(id));
        }

        /// <summary>
        /// Создание нового материале
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///     "nameMaterial": "string",
        ///     "descriptionMaterial": "string",
        ///     "idCategory": 0,
        ///     "idAuthorStatus": 0,
        ///     "idAuthor": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Материал</param>
        /// <returns></returns>

        // POST api/<MaterialController>

        [HttpPost]
        public async Task<IActionResult> Add(Material material)
        {
            await _materialService.Create(material);
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
        ///       "idAuthorStatus": 0,
        ///       "createdBy": 0,
        ///       "lastUpdateBy": 0,
        ///       "deletedBy": 0,
        ///       "fileIcon": 0,
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Материал</param>
        /// <returns></returns>

        // PUT api/<MaterialController>

        [HttpPut]
        public async Task<IActionResult> Update(Material material)
        {
            await _materialService.Update(material);
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