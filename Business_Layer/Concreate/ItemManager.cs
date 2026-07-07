using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Data_Access_Layer.entityframework;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class ItemManager : IItem_Service
    {
        IItem_Dal _itemdal;

        public ItemManager(IItem_Dal itemdal)
        {
            if (itemdal == null)
                throw new ArgumentNullException(nameof(itemdal)); //null dondugu durumlarıda eklememiz lazım
            _itemdal = itemdal;
        }

        public Item GetByID(int id)
        {
            return _itemdal.Get(x => x.ItemId == id);
        }

        public List<Item> GetList()
        {
            return _itemdal.List();
        }

        public void ItemAdd(Item ıtem)
        {
            _itemdal.Insert(ıtem);
        }

        public void ItemDelete(Item ıtem)
        {
            ıtem.ItemStatus = false;
            _itemdal.Update(ıtem);
        }

        public void ItemUpdate(Item ıtem)
        {
            _itemdal.Update(ıtem);
        }

        public List<Item> GetListByFilter(Expression<Func<Item, bool>> filter)
        {
            return _itemdal.List(filter);
        }
    }
}
