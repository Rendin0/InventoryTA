
using System.Collections.Generic;

public class CmdAddItemHandler : ICommandHandler<CmdAddItem>
{
    private readonly Dictionary<string, ItemConfig> _itemConfigs = new();
    private readonly GameStateProxy _gameStateProxy;
    private readonly ICommandProcessor _processor;

    public CmdAddItemHandler(GameStateProxy gameStateProxy, ItemsConfig itemsConfig, ICommandProcessor commandProcessor)
    {
        _gameStateProxy = gameStateProxy;
        _processor = commandProcessor;

        itemsConfig.ItemConfigs.ForEach(config => _itemConfigs.Add(config.ItemId, config));
    }

    // True - ���������� �������� ���� ����
    // False - ���� ���������� �������� �� ���� ����, ���� �� ���������� �������� �����
    public bool Handle(CmdAddItem command)
    {
        var inventoryProxy = _gameStateProxy.InventoryProxy;

        var freeSlot = GetFirstFreeSlotIndex(inventoryProxy, command.ItemId);
        if (freeSlot.index == -1)
            return false;

        // ���� ���� ��������� ����, �� � �� �� ������ ����� �� ���� ����
        if (freeSlot.amount < command.ItemAmount)
        {
            // ����� � ��� ��������� ���� � �������� �������� ����������
            _processor.Process(new CmdAddItemInSlot(freeSlot.index, command.ItemId, freeSlot.amount));
            command.ItemAmount -= freeSlot.amount;
            return _processor.Process(command);
        }

        // ������ ��������� ���� � � �� ������� ����� �� ���� ����
        return _processor.Process(new CmdAddItemInSlot(freeSlot.index, command.ItemId, command.ItemAmount));
    }

    // ������, ���-�� ���������� �����
    private (int index, int amount) GetFirstFreeSlotIndex(InventoryProxy inventoryProxy, string itemId)
    {
        var slotProxies = inventoryProxy.InventorySlotProxies;

        // �������� ������������� ������
        for (int i = 0; i < slotProxies.Count; i++)
        {
            if (slotProxies[i].ItemId.Value == itemId)
            {
                var slotAmount = slotProxies[i].ItemAmount.Value;
                var slotMaxStack = _itemConfigs[itemId].ItemMaxStack;

                if (slotAmount < slotMaxStack)
                    return (i, slotMaxStack - slotAmount);
            }
        }

        // �������� ������ ������
        for (int i = 0; i < slotProxies.Count; i++)
            if (slotProxies[i].ItemId.Value == ItemIDs.Nothing)
                return (i, _itemConfigs[itemId].ItemMaxStack);

        return (-1, -1);
    }
}