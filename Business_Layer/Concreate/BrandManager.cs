using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.entityframework;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class BrandManager : IBrand_Service
    {
       IBrand_Dal _branddal;

        public BrandManager(IBrand_Dal branddal)
        {
            if (branddal == null)
                throw new ArgumentNullException(nameof(branddal)); //null dondugu durumlarıda eklememiz lazım
            _branddal = branddal;
        }

        public void BrandAdd(Brand brand)
        {
            _branddal.Insert(brand);
        }

        public void BrandDelete(Brand brand)
        {
            brand.BrandStatus = false;
            _branddal.Update(brand);
        }

        public void BrandUpdate(Brand brand)
        {
            _branddal.Update(brand);
        }

        public Brand GetByID(int id)
        {
            return _branddal.Get(x => x.BrandId == id);
        }

        public List<Brand> GetList()
        {
            return _branddal.List();
        }
    }
}
