using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReWrite.API.DAL.Context;
using ReWrite.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReWrite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        NWDbContext _context;
        IMapper _mapper;
        public CartController(NWDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("~/api/addCart")]
        public IActionResult AddCart(CartDTO dto)
        {
            return null;
        }
    }
}
