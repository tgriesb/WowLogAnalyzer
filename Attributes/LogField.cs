namespace WowLogAnalyzer.Attributes;

[System.AttributeUsage(System.AttributeTargets.All, Inherited = false, AllowMultiple = false)]
sealed class LogFieldAttribute : System.Attribute
{
    public int Index { get; }
    
    public LogFieldAttribute(int index)
    {
        this.Index = index;
    }
}