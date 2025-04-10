public class GameStateProxy
{
    public InventoryProxy InventoryProxy;

    public GameStateProxy(GameState gameState)
    {
        InventoryProxy = new(gameState.InventoryModel);
    }
}