using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApi
{
    class Model
    {
        public int ModelId { get; set; }

        public int BrandId { get; set; }

        public string ModelName { get; set; }

        public int YearsOfAge { get; set; }

        public decimal Price { get; set; }

        public string Fuel { get; set; }
    }
}
