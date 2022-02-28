public abstract class Action
{
    public abstract bool PerformAction();
    
    public void DoReset()
    {
        Reset();
    }

    protected abstract void Reset();
}