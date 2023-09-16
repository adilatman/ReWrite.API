using AutoMapper;
using ReWrite.API.DAL.Entities;
using ReWrite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.Mapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Cart, CartDTO>();
            CreateMap<CartDTO, Cart>();
            CreateMap<CartDetail, CartDetailDTO>();
            CreateMap<CartDetailDTO, CartDetail>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailDTO, OrderDetail>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Shipper, ShipperDTO>();
            CreateMap<ShipperDTO, Shipper>();
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();
        }        
    }
}
