public class CmdAddItem : ICommand
{
    public string ItemId { get; }

    public int ItemAmount;

    public CmdAddItem(string itemId, int itemAmount)
    {
        ItemId = itemId;
        ItemAmount = itemAmount;
    }

}