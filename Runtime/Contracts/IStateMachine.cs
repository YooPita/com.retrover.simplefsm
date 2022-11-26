namespace Retrover.SimpleFSM
{
    public interface IStateMachine
    {
        public void Execute();
        public void SetState(IState newState);
    }
}