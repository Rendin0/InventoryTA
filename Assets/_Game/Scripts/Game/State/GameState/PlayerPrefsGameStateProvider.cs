
using R3;
using UnityEngine;

public class PlayerPrefsGameStateProvider : IGameStateProvider
{
    private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
    
    public GameStateProxy GameStateProxy { get; private set; }
    private GameState _gameStateOrigin;

    public Observable<GameStateProxy> LoadGameState()
    {
        if (!PlayerPrefs.HasKey(GAME_STATE_KEY))
        {
            GameStateProxy = CreateGameStateFromSettings();

            SaveGameState();
        }
        else
        {
            var json = PlayerPrefs.GetString(GAME_STATE_KEY);
            _gameStateOrigin = JsonUtility.FromJson<GameState>(json);
            GameStateProxy = new GameStateProxy(_gameStateOrigin);
        }
        return Observable.Return(GameStateProxy);
    }
    public Observable<bool> SaveGameState()
    {
        var json = JsonUtility.ToJson(_gameStateOrigin, true);
        PlayerPrefs.SetString(GAME_STATE_KEY, json);

        return Observable.Return(true);
    }
    public Observable<bool> ResetGameState()
    {
        GameStateProxy = CreateGameStateFromSettings();
        SaveGameState();
        return Observable.Return(true);
    }
    private GameStateProxy CreateGameStateFromSettings()
    {
        // —юда можно записать состо€ние по умолчанию
        _gameStateOrigin = new()
        {
            InventoryModel = new(),
        };
        for (int i = 0; i < 20; i++)
        {
            _gameStateOrigin.InventoryModel.InventorySlots.Add(new());
        }

        return new GameStateProxy(_gameStateOrigin);
    }
}