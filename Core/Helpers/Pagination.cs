﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex,int pageSize,int Count,IReadOnlyList<T> Data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = Count;
            this.Data = Data;

        }
        public int Count { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IReadOnlyList<T> Data { get;}
    }
}
