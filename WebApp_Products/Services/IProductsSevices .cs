using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp_Products.Models;
using WebApp_Products.ViewModels;

namespace WebApp_Products.Services
{
    public interface IProductsSevices
    {

       Task <IEnumerable<Product>>GetAll();
       Task <Product> GetById(int id);
       Task Create(AddProductViewModel model);
        Product Update(Product model);
        Product Delete(int id);
       

    }
}
