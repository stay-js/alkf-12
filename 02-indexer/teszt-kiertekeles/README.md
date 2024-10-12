## Group.cs

From:

```csharp
public Result? GetResultByName(string name) => _results?.Find(x => x.Name == name);
```

To:

```csharp
public Result? this[string name] => _results?.Find(x => x.Name == name);
```

## Program.cs

From:

```csharp
var result = group.GetResultByName(name);
```

To:

```csharp
var result = group[name];
```
