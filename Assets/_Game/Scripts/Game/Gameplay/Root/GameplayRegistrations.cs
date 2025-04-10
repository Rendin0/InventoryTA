public static class GameplayRegistrations
{
    public static void Register(DIContainer sceneContainer)
    {
        sceneContainer.RegisterFactory(_ => new InventoryService()).AsSingle();
    }

}