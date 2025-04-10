using R3;

public interface IGameStateProvider
{
    public GameStateProxy GameStateProxy { get; }

    public Observable<GameStateProxy> LoadGameState();
    public Observable<bool> SaveGameState();
    public Observable<bool> ResetGameState();

}