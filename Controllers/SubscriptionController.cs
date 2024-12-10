using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models.Entities;
using ProjetDotNet.Service;

namespace ProjetDotNet.Controllers
{
	public class SubscriptionController : Controller
	{
		private readonly ApplicationDbContext context;

		public SubscriptionController(ApplicationDbContext context)
		{
			this.context = context;
		}


		public IActionResult Index()
		{
			var subscriptions = context.Subscriptions.OrderByDescending(p => p.Id).ToList();
			return View(subscriptions);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(SubscriptionDto subscriptionDto)
		{
			if (!ModelState.IsValid)
			{
				return View(subscriptionDto);
			}
			// Save the new subscription infos
			Subscription subscription = new Subscription()
			{
				Name = subscriptionDto.Name,
				Description = subscriptionDto.Description,
				Price = subscriptionDto.Price,
				CreatedAt = DateTime.Now,
			};
			context.Subscriptions.Add(subscription);
			context.SaveChanges();

			return RedirectToAction("Index", "Subscription");
		}

		public IActionResult Edit(int id)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return RedirectToAction("Index", "Subscription");
			}
			// Save the new subscription infos
			var subscriptionDto = new SubscriptionDto()
			{
				Name = subscription.Name,
				Description = subscription.Description,
				Price = subscription.Price,
			};
			ViewData["SubscriptionId"] = subscription.Id;
			ViewData["CreatedAt"] = subscription.CreatedAt.ToString("dd/MM/yyyy");
			return View();

			//return RedirectToAction("Index", "Subscription");
		}
		[HttpPost]
		public IActionResult Edit(int id, SubscriptionDto subscriptionDto)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return RedirectToAction("Index", "Subscription");

			}
			if (!ModelState.IsValid)
			{
				ViewData["SubscriptionId"] = subscription.Id;
				ViewData["CreatedAt"] = subscription.CreatedAt.ToString("dd/MM/yyyy");
				return View(subscriptionDto);
			}

			// Update the subscription infos (get object by id from DB , then modify its values and save it (because dto do not contain id and createdAt..))
			subscription.Name = subscriptionDto.Name;
			subscription.Description = subscriptionDto.Description;
			subscription.Price = subscriptionDto.Price;


			context.SaveChanges();

			return RedirectToAction("Index", "Subscription");
		}

		public IActionResult Delete(int id)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return RedirectToAction("Index", "Subscription");

			}
			// delete the subscription
			context.Subscriptions.Remove(subscription);
			context.SaveChanges();
			return RedirectToAction("Index", "Subscription");
		}



	}
}
