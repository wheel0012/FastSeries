# FastSeries
forked from melmi/FastSeries
## Introduction

*FastSeries* is a library to store multiple timeseries in binary format. 
This library works best for scenarios that writing performance is has the most importance.
*FastSeries* is not so high performance in reading timeseries. *FastSeries* has zero dependency
to other libraries. *FastSeries* is MIT licensed.

## Format

*FastSeries* orginize timeseries in tables. Each table has a description and pairs of `TimeSpan` and
`float` rows.

## Usage Sample

You can find following sample in `Sample` project of the solution.

### Creating Database

We create a database with two tables.

```C#
FastSeries.Creator.Create("test.db", "temprature (centigrads)", "speed (m/s)");
```

### Writing to Database

Writing to a database is as simple as creating an instance of `Writer` and calling its `WriteItem` method:

```C#
Console.WriteLine(">>> Writing data.");

var writer = new FastSeries.Writer("test.db");

Data data = new Data {
                TableID = 0,
                Time = new TimeSpan(DateTime.Now.Ticks),
                NameField = "hello, world!!!!!".ToCharArray(),
                TypeField = 'I',
                DataField = BitConverter.GetBytes(345678901)
            }; 
writer.WriteItem(data);
writer.Flush();

writer.Close();
```

### Reading from Database

Not much different from writing.

```C#
var reader = new FastSeries.Reader("test.db");

{
    Console.WriteLine(reader.TableDescriptions[0]);
    Console.WriteLine("==========================");
    for (int t = 0; t < 3; ++t)
    {
        var items = reader.TryRead(0, 10);
        foreach (var item in items)
            Console.WriteLine("{0}    {1}", new DateTime(items[i].Item1.Ticks), items[i].Item2.ToString()););
    }
}

{
    Console.WriteLine(reader.TableDescriptions[1]);
    Console.WriteLine("==========================");
    reader.Reset();
    var items = reader.ReadToEnd(1);
    foreach (var item in items)
        Console.WriteLine("{0}    {1}", item.Item1, item.Item2);
}

reader.Close();
```

Please note that you should **NOT** call `Reset` of the of the underlying stream. You can instead use
`Reset` method of `Reader` class itself.
