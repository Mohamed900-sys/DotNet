using Microsoft.AspNetCore.Mvc;
using ProjetDotNet.Models.Entities;
using ProjetDotNet.Service;

namespace ProjetDotNet.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SubscriptionController : ControllerBase
	{
		private readonly ApplicationDbContext context;

		public SubscriptionController(ApplicationDbContext context)
		{
			this.context = context;
		}

		[HttpGet]
		[Route("list")]
		public IActionResult GetAllSubscriptions()
		{
			var subscriptions = context.Subscriptions.OrderByDescending(s => s.Id).ToList();
			return Ok(subscriptions); // Return JSON response
		}

		[HttpGet]
		[Route("details/{id}")]
		public IActionResult GetSubscriptionById(int id)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return NotFound(new { Message = "Subscription not found" });
			}
			return Ok(subscription);
		}

		[HttpPost]
		[Route("add")]
		public IActionResult AddSubscription([FromBody] SubscriptionDto subscriptionDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Subscription subscription = new Subscription
			{
				Name = subscriptionDto.Name,
				Description = subscriptionDto.Description,
				Price = subscriptionDto.Price,
				CreatedAt = DateTime.Now,
			};
			context.Subscriptions.Add(subscription);
			context.SaveChanges();

			return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscription.Id }, subscription);
		}

		[HttpPut]
		[Route("update/{id}")]
		public IActionResult UpdateSubscription(int id, [FromBody] SubscriptionDto subscriptionDto)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return NotFound(new { Message = "Subscription not found" });
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			subscription.Name = subscriptionDto.Name;
			subscription.Description = subscriptionDto.Description;
			subscription.Price = subscriptionDto.Price;
			context.SaveChanges();

			return NoContent(); // Indicates successful update
		}

		[HttpDelete]
		[Route("delete/{id}")]
		public IActionResult DeleteSubscription(int id)
		{
			var subscription = context.Subscriptions.Find(id);
			if (subscription == null)
			{
				return NotFound(new { Message = "Subscription not found" });
			}

			context.Subscriptions.Remove(subscription);
			context.SaveChanges();

			return Ok(new { Message = "Subscription deleted successfully" });
		}
	}
}
