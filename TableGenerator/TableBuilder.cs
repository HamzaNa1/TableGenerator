namespace TableGenerator;

public class TableBuilder:
    ICreateFieldStage,
    IAddSettingsStage,
IAddValuesStage

{
    private List<Field> _fields;

    private TableBuilder()
    {
        _fields = new List<Field>();
    }

    public static ICreateFieldStage CreateTable()
    {
        return new TableBuilder();
    }

    private string _name;
    private string[] _values;
    private FieldType? _type = null;
    private ConsoleColor? _color = null;

    public IAddValuesStage CreateField(string fieldName)
    {
        _name = fieldName;
        _values = Array.Empty<string>();
        _type = null;
        _color = null;

        return this;
    }

    public IAddSettingsStage WithValues(string[] values)
    {
        _values = values;
        return this;
    }

    public IAddSettingsStage WithType(FieldType type)
    {
        _type = type;
        return this;
    }

    public IAddSettingsStage WithColor(ConsoleColor color)
    {
        _color = color;
        return this;
    }

    public ICreateFieldStage AddField()
    {
        Field field = new Field(_name, _values, _type, _color);
        _fields.Add(field);
        return this;
    }
    
    public Table Build()
    {
        Table table = new Table(_fields);

        return table;
    }
}

public interface ICreateFieldStage
{
    public IAddValuesStage CreateField(string fieldName);
    public Table Build();
}

public interface IAddValuesStage
{
    public IAddSettingsStage WithValues(string[] values);
}

public interface IAddSettingsStage
{
    public IAddSettingsStage WithType(FieldType type);
    public IAddSettingsStage WithColor(ConsoleColor color);
    public ICreateFieldStage AddField();
}
