
public class CmdRemoveItemFromSlot : ICommand
{
    public int SlotIndex { get; }
    public int ItemAmount { get; }

    public CmdRemoveItemFromSlot(int slotIndex, int itemAmount)
    {
        SlotIndex = slotIndex;
        ItemAmount = itemAmount;
    }
}