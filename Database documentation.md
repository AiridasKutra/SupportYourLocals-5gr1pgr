# Important

This document outlines the basic usage of the database. Keep in mind that the database will be updated as new features are implemented, therefore, **backwards compatibility is NOT guaranteed**. I will try to make sure old things don't break unexpectedly, and if you run into issues just ask.

**THE CURRENT VERSION WILL BE REPLACED BY A WRAPPER CLASS WHICH WILL SIMPLIFY MANY OF THE THINGS COVERED HERE. THIS WARNING INDICATES THAT THE CURRENT VERSION IS WIP, UNSTANDARDIZED, AND IS HARDER TO WORK WITH THAN LATER VERSIONS.**
The documentation will be updated with every change.

# Setup

To use the database, you first need to connect to the server. This is done by creating a `TCPClient` class instance and calling its `Connect(string ip, ushort port)` function. The function returns `true` if the connection succeeded and `false` otherwise.

If you have the database running locally, the `ip` field should be either `localhost` or `127.0.0.1`. Otherwise pass the ip of the user running the database. The port will be `54000` in virtually all cases.

# Sending packets

To send packets you first need to create a `Packet` class instance. The fields `PacketId` and `ClientId` are unused and can be safely ignored. The `Data` field contains the bytes of what you want to send. Currently you can only send text, which is done by assigning the bytes of the text to the `Data` field and calling `Send(Packet packet)` on a `TCPClient` instance. To convert a string to a byte array you must use `Encoding.ASCII.GetBytes("your text")`.

# Receiving packets

Incoming packets are saved in a queue which returns the oldest received packet by calling `GetPacket()` on a `TCPClient` instance. Before calling the function you should call `PacketCount()` which returns the number of packets currently in the buffer. Trying to get a packet when there are none will throw an `InvalidOperationException`.

To receive the contents of the packet in a string use `Encoding.ASCII.GetString(packet.Data)`

**Important:** The first received packet after calling `Connect()` will either be the text "Connected." or "Server full.". You should wait until the packet is received before doing any further sending/receiving.

# SKL commands (SQL parody)

To receive data from the database you use SKL. It's pretty much useless compared to SQL but has few commands which need to be covered. The surface level of a table in SKL looks like this:
|Attribute names|attr1|attr2|attr3|...|
|-|-|-|-|-|
|row 1|1||no||
|row 2|140|10||
|row 3||9|maybe|
|row 4||6||

The main command is `SELECT attr FROM tablename`, where `attr` can be many attributes separated by commas. It returns a table where only the selected attributes remain. For example, `SELECT attr1 attr2 FROM table1` (lets assume that the table above is named "table1") returns:
|Attribute names|attr1|attr2|
|-|-|-|
|row 1|1||
|row 2|140|10|
|row 3||9|
|row 4||6|

Specifying no attributes returns the entire table.

### Modifiers:
The select command can be supplied with modifiers which help to narrow down the returned results. Currently, the following modifiers can be used:
- `ROW x (TO y)` - Only includes rows x to y. The `TO y` part can be ommited which will mean that only the x-th row is returned.
`SELECT attr1 attr2 FROM table1 ROW 1 TO 2` returns:

|Attribute names|attr1|attr2|
|-|-|-|
|row 1|1||
|row 2|140|10|
- `COMPLETE` - Filters out the rows which don't have the specified attributes.
`SELECT attr1 attr2 FROM table1 COMPLETE` returns:

|Attribute names|attr1|attr2|
|-|-|-|
|row 2|140|10|
- `HAS attr` - Returns only the rows which have the specified attribute (only one per `HAS` allowed). It is pretty much identical to `COMPLETE` but allows to filter by attributes without returning them.
`SELECT attr1 FROM table1 HAS attr3` returns:

|Attribute names|attr1|
|-|-|
|row 1|1|
|row 3||
- `ATTR attr IS (GREATER/LESSER) value` - Allows to filter by value. `GREATER/LESSER` keywords work only on numeric values.
`SELECT attr1 FROM table1 ATTR attr2 IS GREATER 6` returns:

|Attribute names|attr1|
|-|-|
|row 2|140|
|row 3||
- `SELECT attr1 FROM table1 ATTR attr3 IS maybe` returns:

|Attribute names|attr1|
|-|-|
|row 3||


*Note: capitalization is ignored for commands but NOT attribute names*

# So what? (DataList)

The tables drawn above are actually only a representation of the data, but the data itself doesn't even know tables exist. That is because all of the data is stored in a `DataList` class. The basic structure of `DataList` looks like this:
```
class DataList
{
    List<object> items;
    List<string> names;
}
```
That is it.

The SKL commands just interpret a few top layers of `DataList` as a table, even though it's actually just nested lists. When you send an SKL command to the server, it returns a JSON string, which you can convert to a `DataList` structure. For example, the command `SELECT attr1 attr2 FROM table1` (from above) returns:
```json
[
    "row 1",    // Value name
    1,          // Specifies that the value is of type DataList (which number represents what is not important here)
    [           // Value
        "attr1",    // Value name
        2,          // Type (int)
        1           // Value
    ],
    "row 2",
    1,
    [
        "attr1",
        2,
        140,
        "attr2",
        2,
        10
    ],
    "row 3",
    1,
    [
        "attr2",
        2,
        9
    ],
    "row 4",
    1,
    [
        "attr2",
        2,
        6
    ]
]
```
When converted to `DataList` you get a structure like this:
```
row1:
    attr1: 1
row2:
    attr1: 140
    attr2: 10
row3:
    attr2: 9
row4:
    attr2: 6
```
### DataList overview
- `void Add(object item, string name)` - Adds an item with the specified name to the DataList;
- `object Get(int index)` - Returns the object at the specified index. `null` if invalid index;
- `object Get(string name)` - Returns the first object with the specified name. If more than 1 objects with the same name exist the behaviour is undefined. If no objects with the name exist, returns `null`;
- `int Size()` - Returns item count;
- `static List<object> ToList(DataList data)` - Returns the `DataList` as a `List<object>`. Used to convert to Json;
- `static DataList FromList(List<object> list)` - Returns the `List<object>` as a `DataList`. Used to convert from Json;
- `string ToString()` - Returns a string to visualize the `DataList` structure.

**Other notes**:

- `DataList` can contain itself. Conversion functions are recursive and travel through the entire structure;
- When using `Get()` functions, don't forget to convert the result into a valid type (from `object`).

# Code examples

### Connecting to a server and sending/receiving data
```csharp
// Create a TCPClient instance
TCPClient client = new TCPClient();
string ip = Console.ReadLine();

// Try to connect
if (!client.Connect(ip, 54000))
{
    Console.WriteLine("Can't connect");
}
else
{
    // Wait for response
    while (client.PacketCount() < 1)
    {
        Thread.Sleep(10);
    }
    Packet result = client.GetPacket();
    Console.WriteLine(Encoding.ASCII.GetString(result.Data)); // Convert byte array to string

    while (true)
    {
        // Get input
        string input = Console.ReadLine();

        // Create a Packet instance
        Packet pack = new Packet
        {
            PacketId = 0, // Can ignore
            SenderId = 0, // Can ignore
            Data = Encoding.ASCII.GetBytes(input)
        };
        
        // Send the packet
        client.Send(pack);
        
        // Wait for response
        while (client.PacketCount() < 1)
        {
            Thread.Sleep(50);
        }
        
        // Handle packets
        while (client.PacketCount() > 0)
        {
            Packet packet = client.GetPacket();
            string jsonStr = Encoding.ASCII.GetString(packet.Data);
            
            // Json.ToList() converts a json string to a List<object>
            DataList data = DataList.FromList(Json.ToList(jsonStr));
            Console.WriteLine(data.ToString()); 
        }
    }
}
```
### Navigating the DataList structure
Assume that we gathered data using `SELECT FROM events` (get all data).
```csharp
// Continuation from code above
DataList data = DataList.FromList(Json.ToList(jsonStr));

// Iterate the events to find an event with the name "LKL"
DataList event;
for (int i = 0; i < data.Size(); i++)
{
    // The data.items are different events, while data.names is usually just the row number
    if (data.items[i].GetType() == typeof(DataList))
    {
        object obj = ((DataList)data.items[i]).Get("name");
        if (obj == null) continue;
        if (obj.GetType() != typeof(string)) continue;
        if ((string)obj == "LKL")
        {
            event = (DataList)data.items[i];
            break;
        }
    }
}
```
