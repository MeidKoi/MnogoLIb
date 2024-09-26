using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MnogoLibAPI.Contracts.File;
using MnogoLibAPI.Contracts.User;
using File = Domain.Models.File;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }


        /// <summary>
        /// Получение информации о всех файлах
        /// </summary>
        /// <returns></returns>

        // GET api/<FileController>

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Dto = await _fileService.GetAll();

            return Ok(Dto.Adapt<List<GetFileRequest>>());
        }

        /// <summary>
        /// Получение информации о файле по id
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // GET api/<FileController>


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Dto = await _fileService.GetById(id);
            return Ok(Dto.Adapt<GetFileRequest>());
        }


        /// <summary>
        /// Создание нового файла
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///      "nameFile": "string",
        ///      "pathFile": "string",
        ///      "createdBy": 0
        ///     }
        ///
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>

        // POST api/<FileController>

        [HttpPost]
        public async Task<IActionResult> Add(CreateFileRequest file)
        {
            var Dto = file.Adapt<File>();
            Dto.LastUpdateBy = Dto.CreatedBy;
            await _fileService.Create(Dto);
            return Ok();
        }


        /// <summary>
        /// Изменение информации о файле
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///       "idFile": 0,
        ///       "nameFile": "string",
        ///       "pathFile": "string",
        ///       "createdBy": 0,
        ///       "createdTime": "2024-09-19T15:27:09.529Z",
        ///       "lastUpdateBy": 0,
        ///       "lastUpdateTime": "2024-09-19T15:27:09.529Z",
        ///       "deletedBy": 0,
        ///       "deletedTime": "2024-09-19T15:27:09.529Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>

        // PUT api/<FileController>


        [HttpPut]
        public async Task<IActionResult> Update(GetFileRequest file)
        {
            var Dto = file.Adapt<File>();
            await _fileService.Update(Dto);
            return Ok();
        }


        /// <summary>
        /// Удаление файла
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>

        // DELETE api/<FileController>

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _fileService.Delete(id);
            return Ok();
        }
    }
}