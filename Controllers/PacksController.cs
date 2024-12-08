using FitnessWebApp.Models;
using FitnessWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWebApp.Controllers
{
	public class PacksController : Controller
	{
		private readonly ApplicationDbContext context;

		public PacksController(ApplicationDbContext context)
		{
			this.context = context;
		}



        public IActionResult Index()
		{
			var packs = context.Packs.OrderByDescending(p => p.Id).ToList();
			return View(packs);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(PacksDto packsDto)
		{
			if (!ModelState.IsValid)
			{
				return View(packsDto);
			}
			// Save the new pack infos
			Packs pack = new Packs()
			{
				Name = packsDto.Name,
				Description = packsDto.Description,
				Price = packsDto.Price,
				CreatedAt = DateTime.Now,
			};
			context.Packs.Add(pack);
			context.SaveChanges();

			return RedirectToAction("Index", "Packs");
		}

		public IActionResult Edit(int id)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return RedirectToAction("Index", "Packs");
			}
			// Save the new pack infos
			var packsDto = new PacksDto()
			{
				Name = pack.Name,
				Description = pack.Description,
				Price = pack.Price,
			};
			ViewData["PackId"] = pack.Id;
			ViewData["CreatedAt"] = pack.CreatedAt.ToString("dd/MM/yyyy");
			return View();

		}
		[HttpPost]
		public IActionResult Edit(int id, PacksDto packsDto)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return RedirectToAction("Index", "Packs");

			}
			if (!ModelState.IsValid)
			{
				ViewData["PackId"] = pack.Id;
				ViewData["CreatedAt"] = pack.CreatedAt.ToString("dd/MM/yyyy");
				return View(packsDto);
			}

			// Update the pack infos (get object by id from DB , then modify its values and save it (because dto do not contain id and createdAt..))
			pack.Name = packsDto.Name;
			pack.Description = packsDto.Description;
			pack.Price = packsDto.Price;


			context.SaveChanges();

			return RedirectToAction("Index", "Packs");
		}

		public IActionResult Delete(int id)
		{
			var pack = context.Packs.Find(id);
			if (pack == null)
			{
				return RedirectToAction("Index", "Packs");

			}
			// delete the pack
			context.Packs.Remove(pack);
			context.SaveChanges();
			return RedirectToAction("Index", "Packs");
		}
	}
}
