using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Models
{
    public class ItemDetailDescription
    {
        public string DescriptionFull { get; set; }
        public List<Characteristics> Char { get; set; }
    }
}
