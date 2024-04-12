using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using WebApp_Products.Data;
using WebApp_Products.Models;

namespace WebApp_Products.Services
{
    public class CategoriesSevices : ICategoriesSevices
    {
        private readonly ApplicationDbContext _context;

        public CategoriesSevices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category model)
        {
            await _context.AddAsync(model);
            _context.SaveChanges();

            return model;
        }

        public  Category Delete(Category category)
        {
          
             _context.Categories.Remove(category);
             _context.SaveChanges();
            return category;

            }

            public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task <Category?> GetById(int id)
        {
            return await _context.Categories.SingleOrDefaultAsync(g => g.Id == id);

        }

        public Category Update(Category category)
        {
          
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }
        public Task<bool> IsvalidGenre(byte id)
        {
            return _context.Categories.AnyAsync(g => g.Id == id);
        }

        

        public Task<bool> IsvalidCategory(byte id)
        {
            throw new NotImplementedException();
        }

        public Category deletecat(int id)
        {
            var category = _context
               .Categories.FirstOrDefault(c => c.Id == id);

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return (category);
        }
    }
}
