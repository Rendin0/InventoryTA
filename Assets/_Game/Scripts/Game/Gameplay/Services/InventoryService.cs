public class InventoryService
{
    private readonly ICommandProcessor _processor;

    public InventoryService(ICommandProcessor commandProcessor)
    {
        _processor = commandProcessor;
    }

    public bool AddItem(string itemId, int amount = 1)
    {
        var cmd = new CmdAddItem(itemId, amount);
        return _processor.Process(cmd);
    }

    public bool RemoveItem(string itemId, int amount = 1)
    {
        var cmd = new CmdRemoveItem(itemId, amount);
        return _processor.Process(cmd);
    }
}