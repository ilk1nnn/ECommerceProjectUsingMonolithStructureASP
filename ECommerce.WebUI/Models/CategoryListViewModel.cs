using App.Entities.Models;

namespace ECommerce.WebUI
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
        public bool IsClient { get; set; } = true;
    }
}