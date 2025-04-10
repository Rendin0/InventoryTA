public static class GameplayRegistrations
{
    public static void Register(DIContainer sceneContainer)
    {

        var itemsConfig = sceneContainer.Resolve<IConfigProvider>().GameConfig.ItemsConfig;
        var gameStateProvider = sceneContainer.Resolve<IGameStateProvider>();
        var gameStateProxy = gameStateProvider.GameStateProxy;
        var commandProcessor = new CommandProcessor(gameStateProvider);

        commandProcessor.RegisterHandler(new CmdAddItemHandler(gameStateProxy, itemsConfig, commandProcessor));
        commandProcessor.RegisterHandler(new CmdAddItemInSlotHandler(gameStateProxy, itemsConfig));
        commandProcessor.RegisterHandler(new CmdRemoveItemHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdRemoveItemFromSlotHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdAddSlotHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdRemoveSlotHandler(gameStateProxy));

        sceneContainer.RegisterFactory(_ => new InventoryService(commandProcessor)).AsSingle();

        sceneContainer.RegisterInstance<ICommandProcessor>(commandProcessor);

        sceneContainer.RegisterFactory(_ => new GameplayUIManager(sceneContainer)).AsSingle();
        sceneContainer.RegisterFactory(_ => new GameplaySceneUIViewModel()).AsSingle();
    }

}