namespace BoostBottonWpf
{
    public interface IWorkflowAppIdleEvent
    {
        bool Equals(object obj);
        int GetHashCode();
        string ToString();
    }
}