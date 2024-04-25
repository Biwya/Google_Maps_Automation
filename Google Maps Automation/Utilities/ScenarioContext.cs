public class ScenarioContext 
{
    private static ScenarioContext instance;
    private  Dictionary<ContextKeys, dynamic> context;

    private ScenarioContext()
    {
        context = new Dictionary<ContextKeys, object>();
    }

    public static ScenarioContext GetInstance()
    {
        if (instance == null)
        {
            instance = new ScenarioContext();
        }
        return instance;
    }

    public void Save(ContextKeys key, dynamic value)
    {
        context.Add(key, value);
    }

    public dynamic Get(ContextKeys key)
    {
        return context.TryGetValue(key, out dynamic value) ? value : null;
    }

    public void ClearContext()
    {
        context.Clear();
    }
}