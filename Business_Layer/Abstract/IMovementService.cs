using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IMovementService
    {
        void MovementAdd(Movement movement);

        void MovementUpdate(Movement movement);

        void MovementDelete(Movement movement);

        Movement GetByID(int id);

        List<Movement> GetList();
    }
}
