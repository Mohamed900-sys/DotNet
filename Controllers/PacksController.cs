using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models.Entities;
using ProjetDotNet.Service;

namespace ProjetDotNet.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PacksController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public PacksController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		[Route("list")]
		public IActionResult GetAllPacks()
		{
			var packs = context.Packs.OrderByDescending(p => p.Id).ToList();
			return Ok(packs); // Return JSON response
		}

		[HttpGet]
		[Route("details/{id}")]
		public IActionResult GetPackById(int id)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return NotFound(new { Message = "Pack not found" });
			}
			return Ok(pack);
		}

		[HttpPost]
		[Route("add")]
		public IActionResult AddPack([FromBody] PacksDto packsDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Packs pack = new Packs
			{
				Name = packsDto.Name,
				Description = packsDto.Description,
				Price = packsDto.Price,
				CreatedAt = DateTime.Now,
			};
			context.Packs.Add(pack);
			context.SaveChanges();

			return CreatedAtAction(nameof(GetPackById), new { id = pack.Id }, pack);
		}

		[HttpPut]
		[Route("update/{id}")]
		public IActionResult UpdatePack(int id, [FromBody] PacksDto packsDto)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return NotFound(new { Message = "Pack not found" });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			pack.Name = packsDto.Name;
			pack.Description = packsDto.Description;
			pack.Price = packsDto.Price;
			context.SaveChanges();

			return NoContent(); // Indicates successful update
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult DeletePack(int id)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return NotFound(new { Message = "Pack not found" });
			}

			context.Packs.Remove(pack);
			context.SaveChanges();

			return Ok(new { Message = "Pack deleted successfully" });
		}
	}
}
