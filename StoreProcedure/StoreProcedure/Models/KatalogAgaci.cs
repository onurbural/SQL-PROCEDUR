using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProcedure.Models
{
    public class KatalogAgaci
    {
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryID { get; set; }
        public string FullPath { get; set; }
        public int? Level { get; set; }


        public KatalogAgaci[] AltKategoriler { get; set; }



    }
}
