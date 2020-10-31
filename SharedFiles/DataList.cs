using System;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class DataList : IEnumerable
    {
        public List<object> items;
        public List<string> names;

        public DataList()
        {
            items = new List<object>();
            names = new List<string>();
        }

        public DataList(DataList src)
        {
            DataList dest = FromList(ToList(src));
            items = dest.items;
            names = dest.names;
        }

        public int Size()
        {
            return items.Count;
        }

        public bool Add(object item, string name = "")
        {
            items.Add(item);
            names.Add(name);
            return true;
        }

        public bool Add(ListItem item)
        {
            items.Add(item.item);
            names.Add(item.name);
            return true;
        }

        public object Get(int index)
        {
            if (index >= 0 && index < items.Count)
                return items[index];
            else
                return null;
        }

        public object Get(string name)
        {
            int index = names.IndexOf(name);
            if (index != -1)
                return items[index];
            else
                return null;
        }

        public void Remove(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                names.RemoveAt(index);
                items.RemoveAt(index);
            }
        }

        public void Remove(string name)
        {
            for (int i = 0; i < names.Count; i++)
            {
                if (names[i] == name)
                {
                    names.RemoveAt(i);
                    items.RemoveAt(i);
                    return;
                }
            }
        }

        public static List<object> ToList(DataList data)
        {
            List<object> list = new List<object>();
            for (int i = 0; i < data.items.Count; i++)
            {
                list.Add(data.names[i]);
                if (data.items[i] == null)
                {
                    list.Add(Helper.TypeToId(null));
                    list.Add(null);
                }
                else
                {
                    list.Add(Helper.TypeToId(data.items[i].GetType()));
                    if (data.items[i].GetType() == typeof(DataList))
                    {
                        list.Add(ToList((DataList)data.items[i]));
                    }
                    else
                    {
                        list.Add(data.items[i]);
                    }
                }
            }

            return list;
        }

        public static DataList FromList(List<object> list)
        {
            if (list == null) return null;

            if (list.Count % 3 != 0) return null;

            DataList dlist = new DataList();
            for (int i = 0; i < list.Count / 3; i++)
            {
                int index = i * 3;
                if ((int)list[index + 1] == Helper.TypeToId(typeof(DataList)))
                {
                    dlist.Add(FromList((List<object>)list[index + 2]), (string)list[index]);
                }
                else
                {
                    dlist.Add(list[index + 2], (string)list[index]);
                }
            }
            return dlist;
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] == null)
                {
                    str += names[i] + ": null\n";
                    continue;
                }

                if (items[i].GetType() == typeof(DataList))
                {
                    string innerStr = items[i].ToString();
                    string[] innerStrSplit = innerStr.Split('\n');

                    str += names[i] + ":\n";
                    for (int j = 0; j < innerStrSplit.Length; j++)
                    {
                        str += "  " + innerStrSplit[j] + "\n";
                        //if (j != innerStrSplit.Length - 1)
                        //    str += "\n";
                    }
                }
                else
                {
                    str += names[i] + ": " + items[i].ToString() + "\n";
                }
            }

            return str;
        }

        // IEnumerable implementation
        public DataListEnum GetEnumerator()
        {
            return new DataListEnum(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class ListItem
    {
        public object item;
        public string name;
    }

    public class DataListEnum : IEnumerator
    {
        public List<object> items;
        public List<string> names;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public DataListEnum(DataList list)
        {
            items = list.items;
            names = list.names;
        }

        public bool MoveNext()
        {
            position++;
            return (position < items.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public ListItem Current
        {
            get
            {
                try
                {
                    return new ListItem
                    {
                        item = items[position],
                        name = names[position]
                    };
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
