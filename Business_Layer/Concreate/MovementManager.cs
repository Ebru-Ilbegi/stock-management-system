using Business_Layer.Abstract;
using Data_Access_Layer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concreate
{
    public class MovementManager : IMovementService
    {
        IMovement_Dal _movementdal;

        public MovementManager(IMovement_Dal movementdal)
        {
            if (movementdal == null)
                throw new ArgumentNullException(nameof(movementdal));
            _movementdal = movementdal;
        }

        public Movement GetByID(int id)
        {
            return _movementdal.Get(x => x.MovementId == id);
        }

        public List<Movement> GetList()
        {
            return _movementdal.List();
        }

        public void MovementAdd(Movement movement)
        {
            _movementdal.Insert(movement);
        }

        public void MovementDelete(Movement movement)
        {
            movement.MovementStatus = false;
            _movementdal.Update(movement);
        }

        public void MovementUpdate(Movement movement)
        {
            _movementdal.Update(movement);
        }
    }
}
