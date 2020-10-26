using MedicineTrackingSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTrackingSystem.Models
{
    public class Medicine : IDbEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 0;
        [Required]
        public DateTime ExpiryDate { get; set; }
        public string Notes { get; set; }
    }
}
