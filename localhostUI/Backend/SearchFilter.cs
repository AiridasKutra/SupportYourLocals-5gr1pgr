using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace localhostUI.Backend
{
    class SearchFilter
    {
        private class Filter
        {
            private List<Func<DataList, bool>> filters = new List<Func<DataList, bool>>();

            public string Name { get; private set; }
            public bool Strict { get; private set; } // Specifies wether all or only one test must be passed

            public Filter(string name, bool strict = true)
            {
                Name = name;
                Strict = strict;
            }

            public void AddFilter(Func<DataList, bool> filter)
            {
                filters.Add(filter);
            }

            public void Clear()
            {
                filters.Clear();
            }

            public bool Test(DataList data)
            {
                foreach (var filter in filters)
                {
                    bool result = filter.Invoke(data);
                    if (Strict)
                    {
                        if (!result) return false;
                    }
                    else
                    {
                        if (result) return true;
                    }
                }

                // Returns true if all tests passed while Strict == true
                // Returns false if all tests failed while Strict == false
                return Strict;
            }
        }

        private List<Filter> filters = new List<Filter>();

        public SearchFilter()
        {
        }

        public void CreateFilter(string name, bool strict)
        {
            filters.Add(new Filter(name, strict));
        }

        public void CreateAndAddFilter(string name, bool strict, Func<DataList, bool> filter)
        {
            Filter f = new Filter(name, strict);
            f.AddFilter(filter);

            filters.Add(f);
        }

        public bool AddFilter(string name, Func<DataList, bool> filter)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i].Name == name)
                {
                    filters[i].AddFilter(filter);
                    return true;
                }
            }
            return false;
        }

        public bool SetFilter(string name, Func<DataList, bool> filter)
        {
            for (int i = 0; i < filters.Count; i++)
            {
                if (filters[i].Name == name)
                {
                    filters[i].Clear();
                    filters[i].AddFilter(filter);
                    return true;
                }
            }
            return false;
        }

        public bool Test(DataList data)
        {
            foreach (var filter in filters)
            {
                if (!filter.Test(data)) return false;
            }
            return true;
        }
    }
}
