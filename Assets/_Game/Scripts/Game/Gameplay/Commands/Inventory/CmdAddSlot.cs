
using System.Windows.Input;

public class CmdAddSlot : ICommand
{
    public int SlotsAmount { get; }

    public CmdAddSlot(int slotsAmount)
    {
        SlotsAmount = slotsAmount;
    }
}