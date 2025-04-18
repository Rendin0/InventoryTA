using System.Collections.Generic;
using System.Linq;

public class CmdRemoveItemHandler : ICommandHandler<CmdRemoveItem>
{
    private readonly GameStateProxy _gameStateProxy;

    public CmdRemoveItemHandler(GameStateProxy gameStateProxy)
    {
        _gameStateProxy = gameStateProxy;
    }

    public bool Handle(CmdRemoveItem command)
    {
        var inventoryProxy = _gameStateProxy.InventoryProxy;
        var slotProxy = inventoryProxy.InventorySlotProxies.FirstOrDefault(slot => slot.ItemId.Value == command.ItemId);

        // ���� ���� � ����� ��������� �� ��� ������
        if (slotProxy == null)
            return false;

        slotProxy.ItemAmount.Value -= command.ItemAmount;

        if (slotProxy.ItemAmount.Value <= 0)
        {
            slotProxy.ItemAmount.OnNext(0);
            slotProxy.ItemId.OnNext(ItemIDs.Nothing);
        }

        return true;
    }
}