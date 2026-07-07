using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class UserManager : IUser_Service
    {

        IUser_Dal _userdal;

        public UserManager(IUser_Dal userdal)
        {
            if (userdal == null)
                throw new ArgumentNullException(nameof(userdal)); //null dondugu durumlarıda eklememiz lazım
            _userdal = userdal;
        }


        public User GetByID(int id)
        {
            return _userdal.Get(x => x.UserId == id);
        }

        public List<User> GetList()
        {
           return _userdal.List();
        }

        public void UserAdd(User user)
        {
            _userdal.Insert(user);
        }

        public void UserDelete(User user)
        {
            user.UserStatus = false;
            _userdal.Update(user);
        }

        public void UserUpdate(User user)
        {
            _userdal.Update(user);
        }

        public List<User> GetListByFilter(Expression<Func<User, bool>> filter)
        {
            return _userdal.List(filter);
        }

    }
}
