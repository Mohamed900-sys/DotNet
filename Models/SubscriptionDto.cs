﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FitnessWebApp.Models
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
