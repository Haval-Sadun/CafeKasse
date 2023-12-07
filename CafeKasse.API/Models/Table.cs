using CafeKasse.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CafeKasse.API.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TableNumber { get; set; }
        public TableStatus State { get; set; } = TableStatus.Available;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
