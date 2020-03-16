using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Model.QueryResult
{
    public class ProductCategoryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public string Category { get; set; }
        public int IdSubCategory { get; set; }
        public string SubCategory { get; set; }
    }
}
