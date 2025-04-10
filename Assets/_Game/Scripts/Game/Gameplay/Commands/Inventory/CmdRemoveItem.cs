public class CmdRemoveItem : ICommand
{
    public string ItemId { get; }
    public int ItemAmount { get; }

    public CmdRemoveItem(string itemId, int itemAmount)
    {
        ItemId = itemId;
        ItemAmount = itemAmount;
    }
}