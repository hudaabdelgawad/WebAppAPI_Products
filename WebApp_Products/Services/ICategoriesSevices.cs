using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Products.Models;

namespace WebApp_Products.Services
{
    public interface ICategoriesSevices
    {

       Task <IEnumerable<Category>>GetAll();
       Task <Category> GetById(int id);
       Task<Category> Create(Category model);
       Category Update(Category model);
       Category Delete(Category category);
       Task<bool> IsvalidCategory(byte id);
        // public IEnumerable<SelectListItem> GetSelectList();


        //Task<IEnumerable<Genre>> GetAll();
        //Task<Genre> GetById(byte id);
        //Task<Genre> Add(Genre genre);
        //Genre Update(Genre genre);
        //Genre Delete(Genre genre);
        //Task<bool> IsvalidGenre(byte id);
      Category deletecat(int id);


    }
}
