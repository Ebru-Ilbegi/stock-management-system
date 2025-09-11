using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Movement
    {
        [Key]
        public int MovementId { get; set; }

        public int ItemId { get; set; }
        
        [ForeignKey("Warehouse")]
        public int WareHouseId { get; set; }

        [StringLength(10)]
        public string Transaction_Type { get; set; }

        public int Amount { get; set; }

        public DateTime Date { get; set; }

        public bool MovementStatus { get; set; }

        [StringLength(250)]
        public string Destination { get; set; }

        //Connections

        public virtual Item Item { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        
    }
}
