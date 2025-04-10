public class CmdAddSlotHandler : ICommandHandler<CmdAddSlot>
{
    private readonly GameStateProxy _gameStateProxy;

    public CmdAddSlotHandler(GameStateProxy gameStateProxy)
    {
        _gameStateProxy = gameStateProxy;
    }

    public bool Handle(CmdAddSlot command)
    {
        var inventoryProxy = _gameStateProxy.InventoryProxy;

        for (int i = 0; i < command.SlotsAmount; i++)
        {
            var slotModel = new InventorySlotModel();
            inventoryProxy.InventorySlotProxies.Add(new InventorySlotProxy(slotModel));
        }

        return true;
    }
}