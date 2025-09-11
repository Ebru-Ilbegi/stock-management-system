using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IWarehouse_Service
    {
        void WarehouseAdd(Warehouse warehouse);

        void WarehouseUpdate(Warehouse warehouse);

        void WarehouseDelete(Warehouse warehouse);

        Warehouse GetByID(int id);

        List<Warehouse> GetList();
    }
}
