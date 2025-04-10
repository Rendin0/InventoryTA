using System.Collections.Generic;

public class CmdRemoveItemHandler : ICommandHandler<CmdRemoveItem>
{
    private readonly Dictionary<string, ItemConfig> _itemConfigs;

    public CmdRemoveItemHandler(ItemsConfig itemsConfig)
    {
        itemsConfig.ItemConfigs.ForEach(config => _itemConfigs.Add(config.ItemId, config));
    }

    public bool Handle(CmdRemoveItem command)
    {
        return true;
    }
}