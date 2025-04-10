public static class GameplayRegistrations
{
    public static void Register(DIContainer sceneContainer)
    {
        var commandProcessor = new CommandProcessor();

        var itemsConfig = sceneContainer.Resolve<IConfigProvider>().GameConfig.ItemsConfig;
        var gameStateProxy = sceneContainer.Resolve<IGameStateProvider>().GameStateProxy;

        commandProcessor.RegisterHandler(new CmdAddItemHandler(gameStateProxy, itemsConfig, commandProcessor));
        commandProcessor.RegisterHandler(new CmdAddItemInSlotHandler(gameStateProxy, itemsConfig));
        commandProcessor.RegisterHandler(new CmdRemoveItemHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdRemoveItemFromSlotHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdAddSlotHandler(gameStateProxy));
        commandProcessor.RegisterHandler(new CmdRemoveSlotHandler(gameStateProxy));

        sceneContainer.RegisterFactory(_ => new InventoryService(commandProcessor)).AsSingle();

        sceneContainer.RegisterInstance<ICommandProcessor>(commandProcessor);
    }

}