﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class orderItem_DTO
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
    }
}
