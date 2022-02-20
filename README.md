# TableGenerator
 Generates a visual table with a Fluent API  
 
### Example code:
```csharp
Table table = TableBuilder
    .CreateTable()
    .CreateField("ID")
    .WithValues(new []{"1", "2", "3"})
    .AddField()
    .CreateField("Profit")
    .WithValues(new []{"+100", "-100"})
    .AddField()
    .Build();
    
Console.WriteLine(table.ToString());
```

![](https://i.imgur.com/lQwmfGn.png)
