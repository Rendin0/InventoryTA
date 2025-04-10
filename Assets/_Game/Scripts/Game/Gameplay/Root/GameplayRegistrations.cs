public static class GameplayRegistrations
{
    public static void Register(DIContainer sceneContainer)
    {
        var commandProcessor = new CommandProcessor();

        var itemsConfig = sceneContainer.Resolve<IConfigProvider>().GameConfig.ItemsConfig;
        
        commandProcessor.RegisterHandler(new CmdAddItemHandler(itemsConfig, commandProcessor));
        commandProcessor.RegisterHandler(new CmdRemoveItemHandler(itemsConfig));

        sceneContainer.RegisterFactory(_ => new InventoryService(commandProcessor)).AsSingle();

        sceneContainer.RegisterInstance<ICommandProcessor>(commandProcessor);
    }

}