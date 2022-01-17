using Entities;
using System;
using System.Collections.Generic;

namespace DTO
{
    public class order_DTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? OrderSum { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<orderItem_DTO> OrderItems { get; set; }

    }
}
