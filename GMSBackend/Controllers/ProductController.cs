﻿using AutoMapper;
using GMSBackend.Entities;
using GMSBackend.Models;
using GMSBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private DBRepository _dBRepository;

        public ProductController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult> AddProduct([FromBody] Product request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                request.create_date = DateTime.Now;
                request.is_active = true;
                request.is_deleted = false;
                request.coding_id = 1;

                await _dBRepository.product.AddAsync(request);
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = request });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpGet("getProducts")]
        public async Task<ActionResult> GetProducts()   
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lst = await _dBRepository.product.Where(l => l.is_deleted == false).AsNoTracking().ToListAsync();

                return Ok(new CoreResponse() { is_success = true, data = lst });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpGet("getProduct")]
        public async Task<ActionResult> GetProduct(long ID) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var cus = await _dBRepository.product.Where(l => l.id == ID).AsNoTracking().FirstOrDefaultAsync();

                return Ok(new CoreResponse() { is_success = true, data = cus });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }

        [HttpPut("updateProduct")]  
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.product.Where(l => l.id == product.id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no product with this id that passed in.");
                }

                //todo functional below code with extension method
                var mapper = new AutoMapper.Mapper(new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, Account>();
                }));
                mapper.Map(product, obj);

                await _dBRepository.SaveChangesAsync();

                return Ok(new CoreResponse() { is_success = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }


        [HttpDelete("deleteProduct")]   
        public async Task<ActionResult> DeleteProduct(long id)  
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var obj = await _dBRepository.product.Where(l => l.id == id).FirstOrDefaultAsync();
                if (obj == null)
                {
                    throw new Exception("there is no product with this id that passed in.");
                }
                obj.is_deleted = true;
                await _dBRepository.SaveChangesAsync();


                return Ok(new CoreResponse() { is_success = true, data = obj });

            }
            catch (Exception ex)
            {
                return Ok(new CoreResponse() { is_success = false, data = null, dev_message = ex.Message });
            }
        }
    }
}
