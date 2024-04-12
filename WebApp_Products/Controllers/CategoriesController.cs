using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Products.Data;
using WebApp_Products.Models;
using WebApp_Products.Services;

namespace WebApp_Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoriesSevices _categoriesSevices;
        private readonly ApplicationDbContext _context;



        public CategoriesController(ICategoriesSevices categoriesSevices, ApplicationDbContext context)
        {

            _categoriesSevices = categoriesSevices;
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var category = await _categoriesSevices.GetAll();

                return Ok(category);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Save")]
        public IActionResult Save([FromBody] Category model)
        {
            try
            {
                if (model != null)
                {
                    _categoriesSevices.Create(model);

                    return Ok(model);
                }
                return BadRequest(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category model)
        {

            try
            {
                var Result = await _categoriesSevices.GetById(id);
                if (Result != null)
                {
                    Result.Name = model.Name;
                    _categoriesSevices.Update(Result);
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
        [HttpDelete("Delete/{id}")]

        public async Task<IActionResult> Delete(byte id)
        {

            try
            {
                var category = await _categoriesSevices.GetById(id);

                if (category != null)
                {
                    _categoriesSevices.Delete(category);

                    return Ok(category);
                }
                return BadRequest(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("deletecat/{id}")]
        public IActionResult deletecat(int id)
        {
           
          var  category= _categoriesSevices.deletecat(id);

            return Ok(category);

        }

    }
}


