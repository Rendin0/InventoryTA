
using System.Collections.Generic;

public class CmdAddItemHandler : ICommandHandler<CmdAddItem>
{
    private readonly Dictionary<string, ItemConfig> _itemConfigs;
    private readonly ICommandProcessor _processor;

    public CmdAddItemHandler(ItemsConfig itemsConfig, ICommandProcessor commandProcessor)
    {
        _processor = commandProcessor;

        itemsConfig.ItemConfigs.ForEach(config => _itemConfigs.Add(config.ItemId, config));
    }

    public bool Handle(CmdAddItem command)
    {
        return true;
    }
}