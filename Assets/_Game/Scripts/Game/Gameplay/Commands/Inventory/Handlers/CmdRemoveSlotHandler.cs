public class CmdRemoveSlotHandler : ICommandHandler<CmdRemoveSlot>
{
    private readonly GameStateProxy _gameStateProxy;

    public CmdRemoveSlotHandler(GameStateProxy gameStateProxy)
    {
        _gameStateProxy = gameStateProxy;
    }

    public bool Handle(CmdRemoveSlot command)
    {
        var inventoryProxy = _gameStateProxy.InventoryProxy;

        if (inventoryProxy.InventorySlotProxies.Count <= 0)
            return false;

        for (int i = 0; i < command.SlotsAmount; i++)
        {
            inventoryProxy.InventorySlotProxies.RemoveAt(inventoryProxy.InventorySlotProxies.Count - 1);

            if (inventoryProxy.InventorySlotProxies.Count <= 0)
                return false;
        }

        return true;
    }
}