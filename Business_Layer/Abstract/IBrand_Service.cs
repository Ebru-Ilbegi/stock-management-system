using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IBrand_Service
    {
        List<Brand> GetList();
        void BrandAdd(Brand brand);
        void BrandDelete(Brand brand);
        void BrandUpdate(Brand brand);
    }
}
