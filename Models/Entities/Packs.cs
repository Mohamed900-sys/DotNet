﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProjetDotNet.Models.Entities
{
	public class Packs
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
		public string Description { get; set; }
		[Precision(10, 2)]
		public decimal Price { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}
