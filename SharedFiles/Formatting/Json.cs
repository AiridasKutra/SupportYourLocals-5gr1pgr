using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Common.Formatting
{
    class Json
    {
        public static string FromList(List<object> list)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            return JsonSerializer.Serialize(list, options);
        }

        public static List<object> ToList(string jsonStr)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            List<object> fullData = JsonSerializer.Deserialize<List<object>>(jsonStr, options);
            return DecodeList(fullData);
        }

        // Decodes json data recursively
        public static List<object> DecodeList(List<object> list)
        {
            // Must contain sets of 3 elements
            if (list.Count % 3 != 0) return null;

            List<object> decodedList = new List<object>();
            for (int i = 0; i < list.Count / 3; i++)
            {
                int index = i * 3;
                string name = ((JsonElement)list[index]).GetString();
                int typeId = ((JsonElement)list[index + 1]).GetInt32();
                object value;

                var element = (JsonElement)list[index + 2];
                if (Helper.IdToType(typeId) == typeof(DataList))
                {
                    if (element.ValueKind == JsonValueKind.Array)
                    {
                        if (element.GetArrayLength() > 0)
                        {
                            List<object> toDecode = new List<object>();
                            var enumerator = element.EnumerateArray();
                            while (enumerator.MoveNext())
                            {
                                toDecode.Add(enumerator.Current);
                            }

                            value = DecodeList(toDecode);
                        }
                        else
                        {
                            value = new List<object>();
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (Helper.IdToType(typeId) == typeof(string))
                {
                    if (element.ValueKind == JsonValueKind.String)
                    {
                        value = element.GetString();
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (Helper.IdToType(typeId) == typeof(char))
                {
                    if (element.ValueKind == JsonValueKind.String)
                    {
                        string str = element.ToString();
                        if (str.Length == 1)
                        {
                            value = str[0];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else if (Helper.IdToType(typeId) == typeof(bool))
                {
                    if (element.ValueKind == JsonValueKind.True ||
                        element.ValueKind == JsonValueKind.False)
                    {
                        value = element.GetBoolean();
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (element.ValueKind == JsonValueKind.Number)
                    {
                        Type valueType = Helper.IdToType(typeId);
                        if (valueType == typeof(int))
                            value = element.GetInt32();
                        else if (valueType == typeof(double))
                            value = element.GetDouble();
                        else if (valueType == typeof(float))
                            value = element.GetSingle();
                        else if (valueType == typeof(long))
                            value = element.GetInt64();
                        else if (valueType == typeof(byte))
                            value = element.GetByte();
                        else if (valueType == typeof(decimal))
                            value = element.GetDecimal();
                        else if (valueType == typeof(short))
                            value = element.GetInt16();
                        else if (valueType == typeof(uint))
                            value = element.GetUInt32();
                        else if (valueType == typeof(ulong))
                            value = element.GetUInt64();
                        else if (valueType == typeof(ushort))
                            value = element.GetUInt16();
                        else if (valueType == typeof(sbyte))
                            value = element.GetSByte();
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }

                decodedList.Add(name);
                decodedList.Add(typeId);
                decodedList.Add(value);
            }

            return decodedList;
        }
    }
}
