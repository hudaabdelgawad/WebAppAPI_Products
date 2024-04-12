using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using WebApp_Products.Data;
using WebApp_Products.Models;
using WebApp_Products.ViewModels;

namespace WebApp_Products.Services
{
    public class ProductsSevices : IProductsSevices
    {
        private readonly ApplicationDbContext _context;

        public ProductsSevices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(AddProductViewModel model)
        {
            Product item = new()
            {
                Name = model.Name,
                Quintity = model.Quintity,
                Price = model.Price,
                Descount = model.Descount,
                Total = model.Total,
                CategoryId = model.CategoryId


            };
            await _context.AddAsync(item);
            _context.SaveChanges();
           // await _context.AddAsync(model);
          //  _context.SaveChanges();

          //  return model;
        }

        public Product Delete(int id)
        {
            var product = _context
                .Products.FirstOrDefault(c => c.Id == id);

            _context.Products.Remove(product);
             _context.SaveChanges();
            return (product);

            }

       

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products
               

                .Include(C => C.Category).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task <Product?> GetById(int id)
        {
            return await _context.Products.Include(C=>C.Category).SingleOrDefaultAsync(g => g.Id == id);

        }

        public Product Update(Product product)
        {
            
            _context.Update(product);
            _context.SaveChanges();

           return product;
        }
       

       
    }
}
