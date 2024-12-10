using System.ComponentModel.DataAnnotations;

namespace ProjetDotNet.Models.Entities
{
	public class SubscriptionDto
	{
		[Required, MaxLength(100)]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public decimal Price { get; set; }


	}
}
