public class CmdRemoveSlot : ICommand
{
    public int SlotsAmount { get; }

    public CmdRemoveSlot(int slotsAmount)
    {
        SlotsAmount = slotsAmount;
    }
}