using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Turkuaz_WebAPI.Models;
using Turkuaz_WebAPI.Services.Abstract;

namespace Turkuaz_WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ApplicationsController : ControllerBase
	{

		private readonly IAplicationServices _aplicationServices;

		public ApplicationsController(IAplicationServices aplicationServices)
		{
			_aplicationServices = aplicationServices;
		}

		[HttpGet("RemoveComments")]
		public async Task<IActionResult> RemoveComments([FromQuery] RemoveCommentsDTO removeCommentsReqDTO)
		{

			return Ok(_aplicationServices.RemoveComments(removeCommentsReqDTO));
		}

		[HttpGet("FindTheDifference")]
		public async Task<IActionResult> FindTheDifference([FromQuery] FindTheDifferenceDTO findTheDifferenceReqDTO)
		{
			return Ok(_aplicationServices.FindTheDifference(findTheDifferenceReqDTO));
		}
	}
}
