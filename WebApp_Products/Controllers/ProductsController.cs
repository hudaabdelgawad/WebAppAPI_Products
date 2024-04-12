using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApp_Products.Data;
using WebApp_Products.Models;
using WebApp_Products.Services;
using WebApp_Products.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsSevices _productsSevices;
        private readonly ApplicationDbContext _context;

        public ProductsController(IProductsSevices productsSevices,ApplicationDbContext context)
        {
            _productsSevices = productsSevices;
           _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var category = await _productsSevices.GetAll();

                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task< IActionResult> Get(int id)
        {
            var Result = await _productsSevices.GetById(id);
            return Ok(Result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddProductViewModel dto)
        {
            try
            {
                if (dto != null)
                {
               _productsSevices.Create( dto);

                    return Ok(dto);
                }
                return BadRequest(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Save")]
        public IActionResult Save ([FromBody] AddProductViewModel vmodel)
        {
            try
            {
                if (vmodel != null)
                {
                    Product item = new()
            {
                Name = vmodel.Name,
                Quintity=vmodel.Quintity,
                Price=vmodel.Price,
                Descount=vmodel.Descount,
                Total=vmodel.Total,
                CategoryId=vmodel.CategoryId


            };
            var x = _context.Products.Add(item);
            _context.SaveChanges();
            return Ok(vmodel);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddProductViewModel model)
        {


           
            try
            {
                var Result = await _productsSevices.GetById(id);
                if (Result != null)
                {
                    Result.Name = model.Name;
                    Result.CategoryId = model.CategoryId;
                    Result.Descount = model.Descount;
                    Result.Quintity = model.Quintity;
                    Result.Price = model.Price;
                    Result.Total = model.Total;
                    _productsSevices.Update(Result);
                    //_context.Update(Result);
                    //_context.SaveChanges();
                    return Ok(Result);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        ////  [HttpDelete("{id}")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

           
                  var product=  _productsSevices.Delete(id);

                    return Ok(product);
              

        }
    }
}
