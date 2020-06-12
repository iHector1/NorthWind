using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public partial class HomeIndex
    {
        public IList<Products> ProductName { get; set; }
        public IList<Categories> CategoriesName{ get; set; }
        public IList<Suppliers> SupplierName{ get; set; }

    }
}