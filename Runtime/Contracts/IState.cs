namespace Retrover.SimpleFSM
{
    public interface IState
    {
        public void Start();
        public void Execute();
        public IState CalculateNextState();
        public void End();
    }
}