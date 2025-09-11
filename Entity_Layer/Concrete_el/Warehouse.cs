using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Warehouse
    {
        [Key]
        public int WareHouseId { get; set; }

        [StringLength(150)]
        public string WareHouseName { get; set; }

        [StringLength(350)]
        public string WareHouseLocation { get; set; }

        public bool WareHouseStatus { get; set; }

        //Connections

        public ICollection<Item> Items { get; set; }

        public ICollection<Movement> Movements { get; set; }

    }
}
