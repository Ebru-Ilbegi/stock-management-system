using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class CategoryManager : ICategoryService
    {
        ICategory_Dal _categorydal;

        public CategoryManager(ICategory_Dal categorydal)
        {
            if (categorydal == null)
                throw new ArgumentNullException(nameof(categorydal));
            _categorydal = categorydal;
        }

        public void CategoryAdd(Category category)
        {
            _categorydal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            category.CategoryStatus = false;
            _categorydal.Update(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categorydal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categorydal.Get(x => x.CategoryId == id);
        }

        public List<Category> GetList()
        {
            return _categorydal.List(); 
        }
    }
}
