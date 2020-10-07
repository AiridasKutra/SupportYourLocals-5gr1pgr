using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    class Helper
    {
        public static bool IsNumber(object value)
        {
            return value is sbyte
                || value is byte
                || value is short
                || value is ushort
                || value is int
                || value is uint
                || value is long
                || value is ulong
                || value is float
                || value is double
                || value is decimal;
        }

        public static int TypeToId(Type type)
        {
            if (type == null)
                return -1;

            if (type == typeof(string))
                return 0;
            else if (type == typeof(DataList))
                return 1;
            else if (type == typeof(int))
                return 2;
            else if (type == typeof(double))
                return 3;
            else if (type == typeof(float))
                return 4;
            else if (type == typeof(bool))
                return 5;
            else if (type == typeof(byte))
                return 6;
            else if (type == typeof(char))
                return 7;
            else if (type == typeof(decimal))
                return 8;
            else if (type == typeof(long))
                return 9;
            else if (type == typeof(sbyte))
                return 10;
            else if (type == typeof(short))
                return 11;
            else if (type == typeof(uint))
                return 12;
            else if (type == typeof(ulong))
                return 13;
            else if (type == typeof(ushort))
                return 14;
            else
                return -1;
        }

        public static Type IdToType(int id)
        {
            if (id == 0)
                return typeof(string);
            else if (id == 1)
                return typeof(DataList);
            else if (id == 2)
                return typeof(int);
            else if (id == 3)
                return typeof(double);
            else if (id == 4)
                return typeof(float);
            else if (id == 5)
                return typeof(bool);
            else if (id == 6)
                return typeof(byte);
            else if (id == 7)
                return typeof(char);
            else if (id == 8)
                return typeof(decimal);
            else if (id == 9)
                return typeof(long);
            else if (id == 10)
                return typeof(sbyte);
            else if (id == 11)
                return typeof(short);
            else if (id == 12)
                return typeof(uint);
            else if (id == 13)
                return typeof(ulong);
            else if (id == 14)
                return typeof(ushort);
            else
                return null;
        }
    }
}
