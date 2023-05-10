using App.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByFilterAZ(List<Product> list,bool az = false);
        List<Product> GetAllByCategory(int categoryId);
        void Add(Product product);  
        void Update(Product product);
        void Delete(int id);
        Product GetById(int id);


    }
}
