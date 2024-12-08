using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FitnessWebApp.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Precision(10,2)]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
