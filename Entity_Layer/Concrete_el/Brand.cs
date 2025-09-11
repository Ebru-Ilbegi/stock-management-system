using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Concrete
{
    public class Brand
    {
        [Key]
        public int BrandId{ get; set; }
        
        [StringLength(100)]
        public string BrandName { get; set; }

        public bool BrandStatus { get; set; }

        //Connections

        public ICollection<Item> Items { get; set; }

    }
}
