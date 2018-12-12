using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppAspnetcore.ViewModels
{
    public class OrderViewModels
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }

    }
}
