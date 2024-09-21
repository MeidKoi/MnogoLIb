using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.MaterialFile;
using Mapster;
using MnogoLibAPI.Contracts.User;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialFileController : ControllerBase
    {
        private IMaterialFileService _materialFileService;
        public MaterialFileController(IMaterialFileService materialFileService)
        {
            _materialFileService = materialFileService;
        }


        /// <summary>
        /// Получение информации о всех файлах материлов
        /// </summary>
        /// <returns></returns>
        /// 
        // GET api/<MaterialFileController>


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _materialFileService.GetAll();

            return Ok(Dto.Adapt<List<GetMaterialFileRequest>>());
        }

        /// <summary>
        /// Получение информации об файлах материала по id
        /// </summary>
        /// <param name="idMaterial">IDMaterial</param>
        /// <param name="idFile">IDFile</param>
        /// <returns></returns>

        // GET api/<MaterialFileController>

        [HttpGet("{idMaterial}/{idFile}")]
        public async Task<IActionResult> GetById(int idMaterial, int idFile)
        {
            var Dto = await _materialFileService.GetById(idMaterial, idFile);
            return Ok(Dto.Adapt<GetMaterialFileRequest>());
        }

        /// <summary>
        /// Добовление нового файла материалу
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///       "idMaterial": 0,
        ///       "idFile": 0,
        ///       "volume": 0,
        ///       "chapter": 0,
        ///       "frameNumber": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Файл материала</param>
        /// <returns></returns>

        // POST api/<MaterialFileController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateMaterialFileRequest material)
        {
            var Dto = material.Adapt<MaterialFile>();
            await _materialFileService.Create(Dto);
            return Ok();
        }

        /// <summary>
        /// Изменение информации о файлах материала
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idMaterial": 0,
        ///       "idFile": 0,
        ///       "volume": 0,
        ///       "chapter": 0,
        ///       "frameNumber": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="material">Файл материала</param>
        /// <returns></returns>

        // PUT api/<MaterialFileController>

        [HttpPut]
        public async Task<IActionResult> Update(GetMaterialFileRequest material)
        {
            var Dto = material.Adapt<MaterialFile>();
            await _materialFileService.Update(Dto);
            return Ok();
        }

        /// <summary>
        /// Удаление файла материала
        /// </summary>
        /// <param name="idMaterial">IDChat</param>
        /// <param name="idFile">IDUser</param>
        /// <returns></returns>

        // DELETE api/<MaterialFileController>


        [HttpDelete]
        public async Task<IActionResult> Delete(int idMaterial, int idFile)
        {
            await _materialFileService.Delete(idMaterial, idFile);
            return Ok();
        }
    }
}