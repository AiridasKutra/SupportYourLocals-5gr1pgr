using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class Filter
    {
        private List<Func<object, bool>> filters;

        public Filter()
        {
            filters = new List<Func<object, bool>>();
        }

        public void AddFilter(Func<object, bool> f)
        {
            filters.Add(f);
        }

        public void ClearFilters()
        {
            filters.Clear();
        }

        public bool Test(object value)
        {
            foreach (var filter in filters)
            {
                if (!filter.Invoke(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
