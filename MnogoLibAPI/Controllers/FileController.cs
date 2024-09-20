using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _fileService.GetAll());
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
            return Ok(await _fileService.GetById(id));
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
        ///      "pathFile": "string"
        ///     }
        ///
        /// </remarks>
        /// <param name="file">Файл</param>
        /// <returns></returns>

        // POST api/<FileController>

        [HttpPost]
        public async Task<IActionResult> Add(File file)
        {
            await _fileService.Create(file);
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
        public async Task<IActionResult> Update(File file)
        {
            await _fileService.Update(file);
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