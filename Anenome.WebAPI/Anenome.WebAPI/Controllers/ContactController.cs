using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anenome.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		/// <summary>
		/// Takes (id, name, email, type(id, name, customFields(c1, c2, c3)), externalId) and maps it to a contact model.
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		[HttpPost("parse")]
		[Consumes("text/plain")]
		public async Task<IActionResult> Parse([FromBody] string formatMe)
		{
			throw new NotImplementedException();
		}
	}
}
