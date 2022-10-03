using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Core_API.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public double Price { get; set; }
        public string Direction { get; set; }
    }
}
