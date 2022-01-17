using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, order_DTO>().ReverseMap();
            CreateMap<OrderItem, orderItem_DTO>().ReverseMap();
            CreateMap<User, user_DTO>().ReverseMap();
            CreateMap<Product, product_DTO>().ReverseMap();
            CreateMap<Category, category_DTO>().ReverseMap();
        }
    }
}
