using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.Concrete_dal.Repositories;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class WareHouseManager : IWarehouse_Service
    {

       IWareHouse_Dal _warehousedal;

        public WareHouseManager(IWareHouse_Dal warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));
            _warehousedal = warehouse;
        }

        public Warehouse GetByID(int id)
        {
            return _warehousedal.Get(x => x.WareHouseId == id);
        }

        public List<Warehouse> GetList()
        {
            return _warehousedal.List();
        }

        public void WarehouseAdd(Warehouse warehouse)
        {
            _warehousedal.Insert(warehouse);
        }

        public void WarehouseDelete(Warehouse warehouse)
        {
            warehouse.WareHouseStatus = false;
            _warehousedal.Update(warehouse);
        }

        public void WarehouseUpdate(Warehouse warehouse)
        {
            _warehousedal.Update(warehouse);
        }
    }
}
