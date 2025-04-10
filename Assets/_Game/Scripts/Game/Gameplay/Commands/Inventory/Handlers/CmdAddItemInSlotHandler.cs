using System.Collections.Generic;

public class CmdAddItemInSlotHandler : ICommandHandler<CmdAddItemInSlot>
{
    private readonly Dictionary<string, ItemConfig> _itemConfigs;

    public CmdAddItemInSlotHandler(ItemsConfig itemsConfig)
    {
        itemsConfig.ItemConfigs.ForEach(config => _itemConfigs.Add(config.ItemId, config));
    }

    public bool Handle(CmdAddItemInSlot command)
    {


        return true;
    }
}