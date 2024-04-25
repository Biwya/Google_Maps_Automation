public class ScenarioContext 
{
    private static ScenarioContext s_instance;
    private  Dictionary<ContextKeys, dynamic> _context;

    private ScenarioContext()
    {
        _context = new Dictionary<ContextKeys, object>();
    }

    public static ScenarioContext GetInstance()
    {
        if (s_instance == null)
        {
            s_instance = new ScenarioContext();
        }
        return s_instance;
    }

    public void Save(ContextKeys key, dynamic value)
    {
        _context.Add(key, value);
    }

    public dynamic Get(ContextKeys key)
    {
        return _context.TryGetValue(key, out dynamic value) ? value : null;
    }

    public void ClearContext()
    {
        _context.Clear();
    }
}