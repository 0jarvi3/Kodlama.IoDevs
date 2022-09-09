using Application.Futures.ProgrammingLanguages.Commands.CreateProgrammingLanguages;
using Application.Futures.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Futures.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Futures.ProgrammingLanguages.Dtos;
using Application.Futures.ProgrammingLanguages.Models;
using Application.Futures.ProgrammingLanguages.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand command)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Update([FromBody] DeleteProgrammingLanguageCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }



        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
