using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IItem_Service
    {
        List<Item> GetList();
        void ItemAdd(Item ıtem);

        Item GetByID(int id);

        void ItemDelete(Item ıtem);

        void ItemUpdate(Item ıtem);
    }
}
