namespace Retrover.SimpleFSM
{
    public class StateMachine : IStateMachine
    {
        public StateMachine(IState initialState)
        {
            SetState(initialState);
        }

        private IState _currentState;

        public void Execute()
        {
            IState tempState = _currentState;
            _currentState.Execute();
            if (tempState != _currentState) return;
            var nextState = _currentState.CalculateNextState();
            if (nextState != tempState) SetState(nextState);
        }

        public void SetState(IState newState)
        {
            if (_currentState != null) _currentState.End();
            _currentState = newState;
            _currentState.Start();
        }
    }
}