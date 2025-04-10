public static class GameplayRegistrations
{
    public static void Register(DIContainer sceneContainer)
    {
        var commandProcessor = new CommandProcessor();

        commandProcessor.RegisterHandler(new CmdAddItemHandler());
        commandProcessor.RegisterHandler(new CmdRemoveItemHandler());

        sceneContainer.RegisterFactory(_ => new InventoryService(commandProcessor)).AsSingle();

        sceneContainer.RegisterInstance<ICommandProcessor>(commandProcessor);
    }

}