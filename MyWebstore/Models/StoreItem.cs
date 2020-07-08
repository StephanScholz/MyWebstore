using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebstore.Models
{
    public class StoreItem
    {
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Title { get; set; }
        [StringLength(70)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal? Price { get; set; }

    }
}
