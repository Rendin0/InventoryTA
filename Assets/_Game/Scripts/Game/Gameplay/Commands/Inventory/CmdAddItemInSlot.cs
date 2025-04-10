public class CmdAddItemInSlot : ICommand
{
    public int SlotIndex { get; }

    public string ItemId;
    public int ItemAmount;

    public CmdAddItemInSlot(int slotIndex, string itemId, int itemAmount)
    {
        SlotIndex = slotIndex;
        ItemId = itemId;
        ItemAmount = itemAmount;
    }

}