namespace TableGenerator;

public struct Field
{
    public string Name { get; }
    public string[] Values { get; }
    public FieldType Type { get; }
    public ConsoleColor Color { get; }

    private const FieldType DefaultFieldType = FieldType.Label;
    private const ConsoleColor DefaultConsoleColor = ConsoleColor.Gray;

    public Field(string name, string[] values, FieldType? type = null, ConsoleColor? color = null)
    {
        Name = name;
        Values = values;
        Type = type ?? DefaultFieldType;
        Color = color ?? DefaultConsoleColor;
    }
}