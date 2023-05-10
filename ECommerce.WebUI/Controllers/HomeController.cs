using ECommerce.WebUI.ExtentionMethods;
using ECommerce.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        //public string Index()
        //{

        //    HttpContext.Session.SetInt32("age", 25);
        //    HttpContext.Session.SetString("name", "John Johnlu");

        //    var student = new StudentTest
        //    {
        //        Id = 1,
        //        Name = "Leyla",
        //        Surname = "Aliyeva"
        //    };
        //    HttpContext.Session.SetObject("student", student);

        //    return "Session Created";
        //}

        //public string GetSession()
        //{
        //    return $"Age {HttpContext.Session.GetInt32("age")}"+
        //           $"Name {HttpContext.Session.GetString("name")}";
        //}

        //public string GetStudent()
        //{
        //    var item = HttpContext.Session.GetObject<StudentTest>("student");
        //    return $"{item.Id}  -  {item.Name}  -  {item.Surname}";
        //}


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}