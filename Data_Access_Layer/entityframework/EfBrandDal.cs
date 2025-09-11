using Data_Access_Layer.Abstract;
using Data_Access_Layer.Concrete_dal.Repositories;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.entityframework
{
    public class EfBrandDal : GenericRepository<Brand> , IBrand_Dal
    {
    }
}
