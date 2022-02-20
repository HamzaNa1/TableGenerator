using System.Text;

namespace TableGenerator;

public class Table
{
    private readonly List<Field> _fields;
    private bool _change;

    private readonly StringBuilder _stringBuilder = new StringBuilder();

    public Table()
    {
        _fields = new List<Field>();
    }

    public Table(IEnumerable<Field> fields)
    {
        _fields = fields.ToList();
        _change = true;
    }

    public void AddField(Field field)
    {
        _fields.Add(field);
        _change = true;
    }

    private void Build()
    {
        int[] sizes = new int[_fields.Count];
        for (int i = 0; i < _fields.Count; i++)
        {
            Field field = _fields[i];

            int max = field.Name.Length;
            for (int j = 0; j < field.Values.Length; j++)
            {
                string value = field.Values[j];

                max = Math.Max(max, value.Length);
            }

            sizes[i] = max;
        }

        int height = _fields.Max(x => x.Values.Length);
        
        _stringBuilder.Clear();
        _stringBuilder.Append("┌─");
        for (int i = 0; i < sizes.Length; i++)
        {
            _stringBuilder.Append(new string('─', sizes[i]));
            if (i != _fields.Count - 1)
            {
                _stringBuilder.Append("─┬─");
            }
        }
        _stringBuilder.Append("─┐");
        _stringBuilder.Append(Environment.NewLine);   
        
        _stringBuilder.Append("│ ");
        for (int i = 0; i < _fields.Count; i++)
        {
            Field field = _fields[i];
            
            _stringBuilder.Append(field.Name);
            _stringBuilder.Append(new string(' ', sizes[i] - field.Name.Length));

            if (i != _fields.Count - 1)
            {
                _stringBuilder.Append(" │ ");
            }
        }
        _stringBuilder.Append(" │");
        _stringBuilder.Append(Environment.NewLine);
        
        _stringBuilder.Append("├─");
        for (int i = 0; i < sizes.Length; i++)
        {
            _stringBuilder.Append(new string('─', sizes[i]));
            if (i != _fields.Count - 1)
            {
                _stringBuilder.Append("─┼─");
            }
        }
        _stringBuilder.Append("─┤");
        _stringBuilder.Append(Environment.NewLine);

        for (int i = 0; i < height; i++)
        {
            _stringBuilder.Append("│ ");

            for (int j = 0; j < _fields.Count; j++)
            {
                Field field = _fields[j];
                string[] values = field.Values;

                if (values.Length > i)
                {
                    _stringBuilder.Append(values[i]);
                    _stringBuilder.Append(new string(' ', sizes[j] - values[i].Length));
                }
                else
                {
                    _stringBuilder.Append(new string(' ', sizes[j]));
                }
                
                if (j != _fields.Count - 1)
                {
                    _stringBuilder.Append(" │ ");
                }
            }
            
            _stringBuilder.Append(" │");
            _stringBuilder.Append(Environment.NewLine);
        }
        
        _stringBuilder.Append("└─");
        for (int i = 0; i < sizes.Length; i++)
        {
            _stringBuilder.Append(new string('─', sizes[i]));
            if (i != _fields.Count - 1)
            {
                _stringBuilder.Append("─┴─");
            }
        }
        _stringBuilder.Append("─┘");
        _stringBuilder.Append(Environment.NewLine);
    }

    public override string ToString()
    {
        if (_change)
        {
            Build();
            _change = false;
        }
        
        return _stringBuilder.ToString();
    }
}