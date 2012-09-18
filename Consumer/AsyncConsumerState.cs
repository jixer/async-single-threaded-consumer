namespace Cjam.Threading.Consumer
{
    public enum AsyncConsumerState
    {
        Initializing,
        Active,
        Waiting,
        Executing,
        Finishing,
        Finished
    }
}
