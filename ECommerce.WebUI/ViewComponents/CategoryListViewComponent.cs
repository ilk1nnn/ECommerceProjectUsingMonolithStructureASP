using App.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Security.Claims;

namespace ECommerce.WebUI.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        private ICategoryService _categoryService;
        private IHttpContextAccessor _contextAccessor;

        public CategoryListViewComponent(ICategoryService categoryService, IHttpContextAccessor contextAccessor)
        {
            _categoryService = categoryService;
            _contextAccessor = contextAccessor;
        }

        public ViewViewComponentResult Invoke()
        {
            var user = _contextAccessor.HttpContext.User;
            string role = "";
            if (user.Claims.Count()!=0)
            {
                role = user.FindFirst(ClaimTypes.Role).Value;
            }
            bool isAdmin = false;
            if (role == "Admin")
            {
                isAdmin = true;
            }
            var model = new CategoryListViewModel
            {
                IsClient = !isAdmin,
                Categories = _categoryService.GetAll(),
                CurrentCategory = Convert.ToInt32(HttpContext.Request.Query["category"])
            };
            return View(model);
        }
    }
}
