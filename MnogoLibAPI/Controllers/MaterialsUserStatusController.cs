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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _materialsUserStatusService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int idMaterials, int idUser, int idUserStatus)
        {
            return Ok(await _materialsUserStatusService.GetById(idMaterials, idUser, idUserStatus));
        }

        [HttpPost]
        public async Task<IActionResult> Add(MaterialsUserStatus materialsUserStatusService)
        {
            await _materialsUserStatusService.Create(materialsUserStatusService);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(MaterialsUserStatus materialsUserStatusService)
        {
            await _materialsUserStatusService.Update(materialsUserStatusService);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idMaterials, int idUser, int idUserStatus)
        {
            await _materialsUserStatusService.Delete(idMaterials, idUser, idUserStatus);
            return Ok();
        }
    }
}