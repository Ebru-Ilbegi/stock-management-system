using Data_Access_Layer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IUser_Service
    {
        List<User> GetList();
        void UserAdd(User user);

        User GetByID(int id);

        void UserDelete(User user);

        void UserUpdate(User user);

    }
}
