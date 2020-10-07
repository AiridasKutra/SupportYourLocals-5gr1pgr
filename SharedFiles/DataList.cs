using System.Collections.Generic;

namespace Common
{
    class DataList
    {
        public List<object> items;
        public List<string> names;

        public DataList()
        {
            items = new List<object>();
            names = new List<string>();
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
    }
}
