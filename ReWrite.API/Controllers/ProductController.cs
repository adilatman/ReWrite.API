using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReWrite.API.DAL.Context;
using ReWrite.API.DAL.Entities;
using ReWrite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        NWDbContext _context;
        IMapper _mapper;
        public ProductController(NWDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("")]
        public IActionResult GetProducts()
        {
            var products = (from p in _context.Product
                            join c in _context.Category on p.CategoryID equals c.CategoryID
                            join s in _context.Supplier on p.SupplierID equals s.SupplierID
                            select new ProductWithNamesDTO()
                            {
                                ProductID=p.ProductID,
                                ProductName=p.ProductName,
                                CategoryID=p.CategoryID,
                                SupplierID=p.SupplierID,
                                UnitsInStock=p.UnitsInStock,
                                Discontinued=p.Discontinued,
                                QuantityPerUnit=p.QuantityPerUnit,
                                ReorderLevel=p.ReorderLevel,
                                UnitPrice=p.UnitPrice,
                                UnitsOnOrder=p.UnitsOnOrder,
                                CategoryName=c.CategoryName,
                                CompanyName=s.CompanyName
                            }).ToList();
            return Ok(products);
        }
        [HttpPost]
        [Route("~/api/addProduct")]
        public IActionResult AddProduct([FromBody]ProductDTO dto)
        {
            _context.Product.Add(_mapper.Map<Product>(dto));
            _context.SaveChanges();
            return Ok("Added!");
        }
    }
}
