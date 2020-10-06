using Database.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Database
{
    class Database
    {
        private DataList data;

        public Database(string filename)
        {
            data = new DataList();
            {
                DataList row1 = new DataList();
                row1.Add("birkaciulpis", "name");
                row1.Add("tavo mama", "location");
                row1.Add("bybe ciulpims", "sport");
                row1.Add(4.20, "price");
                DataList teams1 = new DataList();
                teams1.Add("evaldas");
                teams1.Add("byberis");
                row1.Add(teams1, "teams");

                DataList row2 = new DataList();
                row2.Add("birkaciulpis2elektrinisbugalu", "name");
                row2.Add("tavo mama", "location");
                row2.Add("bybe ciulpims", "sport");
                row2.Add(6.99, "price");
                DataList teams2 = new DataList();
                teams2.Add("evaldas");
                teams2.Add("byberis");
                row2.Add(teams2, "teams");
                row2.Add("karsti ceburekai drungnas alus", "description");

                DataList row3 = new DataList();
                row3.Add("birkaciulpis3tugaidys", "name");
                row3.Add("tavo mama vel", "location");
                row3.Add("bybe ciulpims", "sport");
                row3.Add(13.37, "price");
                DataList teams3 = new DataList();
                teams3.Add("evaldas");
                teams3.Add("byberis");
                row3.Add(teams3, "teams");

                DataList row4 = new DataList();
                row4.Add("birkaciulpis4tikiuosipenktonebus", "name");
                row4.Add("tavo mama vis dar", "location");
                row4.Add("bybe ciulpims", "sport");
                row4.Add('@', "price");
                DataList teams4 = new DataList();
                teams4.Add("evaldas");
                teams4.Add("byberis");
                row4.Add(teams4, "teams");
                row4.Add("nu blet jau paskutinis tikiuojs", "description");

                DataList table = new DataList();
                table.Add(row1, "1");
                table.Add(row2, "2");
                table.Add(row3, "3");
                table.Add(row4, "4");

                data.Add(table, "birkakakliu_kaimo_perlai");
            }

            //SaveToFile("data.json");
            Load(new JsonFileReader("data.json"));
        }

        public object Execute(string command, object[] args)
        {
            string[] commlets = command.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (commlets.Length == 0) return null;

            switch (commlets[0])
            {
                // Regular commands
                case "select":
                    {
                        return ExSelect(commlets);
                    }

                // Admin commands

                default:
                    return null;
            }
        }

        private object ExSelect(string[] commlets)
        {
            try
            {
                if (commlets.Length < 3) return null;

                int comIndex = 1;

                // Find all attributes
                List<string> attrs = new List<string>();
                while (commlets[comIndex] != "from")
                {
                    attrs.Add(commlets[comIndex++]);
                }

                // Read table name
                comIndex++;
                string tableName = commlets[comIndex++];

                // Read additional parameters
                List<Filter> filters = new List<Filter>();
                List<string> attrNames = new List<string>();
                int rowLower = 0;
                int rowUpper = int.MaxValue;
                bool complete = false;
                List<string> mustContain = new List<string>();
                while (comIndex < commlets.Length)
                {
                    if (commlets[comIndex] == "row")
                    {
                        int lowerBound;
                        int upperBound;
                        if (int.TryParse(commlets[++comIndex], out lowerBound))
                        {
                            if (comIndex == commlets.Length - 1)
                            {
                                upperBound = lowerBound;
                                rowLower = lowerBound;
                                rowUpper = upperBound;
                                break;
                            }
                            else if (commlets[++comIndex] == "to")
                            {
                                if (!int.TryParse(commlets[++comIndex], out upperBound))
                                {
                                    return null;
                                }
                            }
                            else
                            {
                                comIndex--;
                                upperBound = lowerBound;
                            }
                        }
                        else return null;

                        rowLower = lowerBound;
                        rowUpper = upperBound;
                    }
                    else if (commlets[comIndex] == "complete")
                    {
                        complete = true;
                    }
                    else if (commlets[comIndex] == "has")
                    {
                        mustContain.Add(commlets[++comIndex]);
                    }
                    else if (commlets[comIndex] == "attr")
                    {
                        string attrName = commlets[++comIndex];
                        if (commlets[++comIndex] != "is") return null;

                        // Check if any filters for a given attribute already exist
                        int filterIndex = filters.Count;
                        if (attrNames.Contains(attrName))
                        {
                            filterIndex = attrNames.IndexOf(attrName);
                        }
                        else
                        {
                            filters.Add(new Filter());
                            attrNames.Add(attrName);
                        }


                        comIndex++;
                        if (commlets[comIndex] == "greater")
                        {
                            double value = double.Parse(commlets[++comIndex]);
                            filters[filterIndex].AddFilter(val =>
                            {
                                if (!Helper.IsNumber(val)) return false;
                                return (double)val > value;
                            });
                        }
                        else if (commlets[comIndex] == "lesser")
                        {
                            double value = double.Parse(commlets[++comIndex]);
                            filters[filterIndex].AddFilter(val =>
                            {
                                if (!Helper.IsNumber(val)) return false;
                                return (double)val < value;
                            });
                        }
                        else
                        {
                            double value = double.Parse(commlets[++comIndex]);
                            filters[filterIndex].AddFilter(val =>
                            {
                                if (!Helper.IsNumber(val)) return false;
                                return (double)val == value;
                            });
                        }
                    }
                    else
                    {
                        return null;
                    }

                    //filters.AddFilter(val => val.ToString() == "text");
                    comIndex++;
                }


                // Select appropriate items
                int tableIndex = data.names.IndexOf(tableName);
                if (tableIndex == -1) return null;
                if (data.items[tableIndex].GetType() != typeof(DataList)) return null;

                DataList table = (DataList)data.items[tableIndex];
                DataList finalTable = new DataList();
                for (int i = rowLower; i <= rowUpper && i < table.Size(); i++)
                {
                    object rowItem = table.items[i];
                    string rowName = table.names[i];
                    if (rowItem.GetType() != typeof(DataList)) continue;
                    DataList row = (DataList)rowItem;

                    // Check for required attributes
                    bool isComplete = true;
                    bool hasAttributes = true;
                    void Loop()
                    {
                        if (complete)
                        {
                            for (int j = 0; j < attrs.Count; j++)
                            {
                                if (row.names.IndexOf(attrs[j]) == -1)
                                {
                                    isComplete = false;
                                    return;
                                }
                            }
                        }
                        for (int k = 0; k < mustContain.Count; k++)
                        {
                            if (row.names.IndexOf(mustContain[k]) == -1)
                            {
                                hasAttributes = false;
                                return;
                            }
                        }
                    }
                    Loop();
                    if (!isComplete) continue;
                    if (!hasAttributes) continue;

                    // Filter out
                    bool passes = true;
                    for (int j = 0; j < attrNames.Count; j++)
                    {
                        int index = row.names.IndexOf(attrNames[j]);
                        if (index != -1)
                        {
                            if (!filters[j].Test(row.items[index]))
                            {
                                passes = false;
                                break;
                            }
                        }
                    }
                    if (!passes) continue;

                    // Add row items to final table
                    if (attrs.Count == 0)
                    {
                        finalTable.Add(row, rowName);
                    }
                    else
                    {
                        DataList trimmedRow = new DataList();
                        for (int j = 0; j < attrs.Count; j++)
                        {
                            int index = row.names.IndexOf(attrs[j]);
                            if (index == -1)
                            {
                                trimmedRow.Add(null, attrs[j]);
                            }
                            else
                            {
                                trimmedRow.Add(row.items[index], attrs[j]);
                            }
                        }
                        finalTable.Add(trimmedRow, rowName);
                    }
                }

                // Return final table
                return finalTable;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        public void Save(IDataWriter writer)
        {
            //JsonFileIO.Write(filename, DataList.ToList(data));
            writer.Write(data);
        }

        public void Load(IDataReader reader)
        {
            //data = DataList.FromList(JsonFileIO.Read(filename));
            reader.Read(out data);
        }

        public void Print()
        {
            for (int i = 0; i < data.Size(); i++)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("| " + data.names[i] + " |");
                Console.WriteLine("-----------------------------");
                Console.Write(data.items[i].ToString());
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
