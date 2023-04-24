using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.ProductHelperParam
{
    public class ProductHelpParam
    {
        private const int MaxPages = 60;
        public int PageIndex { get; set; } = 1;
        private int _PageSize { get; set; }

        public int PageSize
        {
            get => _PageSize;
            set => _PageSize = (value > MaxPages) ? MaxPages : value;
        }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; }

        private string _Search { get; set; }
        public string Search
        {
            get => _Search;
            set => _Search = value.ToLower();
        }

    }
}
