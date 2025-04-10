
using System.Linq;

public class CmdRemoveItemFromSlotHandler : ICommandHandler<CmdRemoveItemFromSlot>
{
    private readonly GameStateProxy _gameStateProxy;

    public CmdRemoveItemFromSlotHandler(GameStateProxy gameStateProxy)
    {
        _gameStateProxy = gameStateProxy;
    }

    public bool Handle(CmdRemoveItemFromSlot command)
    {
        var inventoryProxy = _gameStateProxy.InventoryProxy;

        // Попытка удалить предмет из слота за пределами инвентаря
        if (command.SlotIndex >= inventoryProxy.InventorySlotProxies.Count)
            return false;

        var slotProxy = inventoryProxy.InventorySlotProxies[command.SlotIndex];

        slotProxy.ItemAmount.Value -= command.ItemAmount;

        if (slotProxy.ItemAmount.Value <= 0)
        {
            slotProxy.ItemAmount.OnNext(0);
            slotProxy.ItemId.OnNext(ItemIDs.Nothing);
        }

        return true;
    }
}