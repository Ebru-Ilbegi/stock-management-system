using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [StringLength(100)]
        public string ItemName { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int Stock { get; set; }

        public bool ItemStatus { get; set; }

        public float Unit_Price { get; set; }

        public int WareHouseId { get; set; }

        //Connections

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public ICollection<Movement> Movements { get; set; }
    }
}
