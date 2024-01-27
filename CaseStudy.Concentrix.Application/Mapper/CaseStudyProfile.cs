using AutoMapper;
using CaseStudy.Concentrix.Abstraction.Model;
using CaseStudy.Concentrix.Domain;
using CaseStudy.Concentrix.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Application.Mapper
{
    public class CaseStudyProfile :Profile
    {
        public CaseStudyProfile()
        {
            CreateMap<Order, OrderEntity>().ReverseMap();
            CreateMap<OrderItem, OrderItemEntity>().ReverseMap();
            CreateMap<Address, AddressEntity>().ReverseMap();
        }
    }
}
