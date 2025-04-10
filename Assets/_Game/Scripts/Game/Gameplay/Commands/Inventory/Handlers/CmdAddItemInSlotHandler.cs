using System.Collections.Generic;

public class CmdAddItemInSlotHandler : ICommandHandler<CmdAddItemInSlot>
{
    private readonly Dictionary<string, ItemConfig> _itemConfigs = new();
    private readonly GameStateProxy _gameStateProxy;

    public CmdAddItemInSlotHandler(GameStateProxy gameStateProxy, ItemsConfig itemsConfig)
    {
        itemsConfig.ItemConfigs.ForEach(config => _itemConfigs.Add(config.ItemId, config));
        _gameStateProxy = gameStateProxy;
    }

    public bool Handle(CmdAddItemInSlot command)
    {
        var slotProxy = _gameStateProxy.InventoryProxy.InventorySlotProxies[command.SlotIndex];

        // Если слот пустой
        if (slotProxy.ItemId.Value == ItemIDs.Nothing)
        {
            slotProxy.ItemId.OnNext(command.ItemId);
            slotProxy.ItemAmount.OnNext(command.ItemAmount);
            return true;
        }

        // Лежит другой предмет, нельзя стакать
        if (slotProxy.ItemId.Value != command.ItemId)
        {
            // Свап предмета из слота в команду для последущей обработки
            var tmpId = command.ItemId;
            var tmpAmount = command.ItemAmount;

            command.ItemId = slotProxy.ItemId.Value;
            command.ItemAmount = slotProxy.ItemAmount.Value;

            slotProxy.ItemId.OnNext(tmpId);
            slotProxy.ItemAmount.OnNext(tmpAmount);
            return false;
        }

        var maxStack = _itemConfigs[command.ItemId].ItemMaxStack;
        var amountInSlot = slotProxy.ItemAmount.Value;
        // Лежит такой же предмет, но не хватает места
        if (amountInSlot + command.ItemAmount > maxStack)
        {
            slotProxy.ItemAmount.OnNext(maxStack);
            command.ItemAmount -= maxStack - amountInSlot;

            return false;
        }

        // Лежит такой же предмет, хватает места
        slotProxy.ItemAmount.OnNext(amountInSlot + command.ItemAmount);
        return true;
    }
}