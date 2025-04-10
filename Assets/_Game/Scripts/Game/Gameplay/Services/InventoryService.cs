public class InventoryService
{
    private readonly ICommandProcessor _processor;

    public InventoryService(ICommandProcessor commandProcessor)
    {
        _processor = commandProcessor;
    }

    #region Slots
    public bool AddSlot(int slotsAmount = 1)
    {
        var cmd = new CmdAddSlot(slotsAmount);
        return _processor.Process(cmd);
    }

    public bool RemoveSlot(int slotsAmount = 1)
    {
        var cmd = new CmdRemoveSlot(slotsAmount);
        return _processor.Process(cmd);
    }
    #endregion

    #region Items
    public bool AddItem(string itemId, int amount = 1)
    {
        var cmd = new CmdAddItem(itemId, amount);
        return _processor.Process(cmd);
    }

    public bool AddItemInSlot(int slotIndex, string itemId, int amount = 1)
    {
        var cmd = new CmdAddItemInSlot(slotIndex, itemId, amount);
        return _processor.Process(cmd);
    }

    public bool RemoveItem(string itemId, int amount = 1)
    {
        var cmd = new CmdRemoveItem(itemId, amount);
        return _processor.Process(cmd);
    }

    public bool RemoveItemFromSlot(int slotIndex, int amount = 1)
    {
        var cmd = new CmdRemoveItemFromSlot(slotIndex, amount);
        return _processor.Process(cmd);
    }
    #endregion
}