using Zenject;

public class AppStarter : IInitializable
{
    private readonly StateMachine _stateMachine;


    public AppStarter(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Initialize()
    {
        _stateMachine.MoveToState(GameState.Start);
    }
}
