
using R3;

public class InventorySlotProxy
{
    public ReactiveProperty<string> ItemId { get; } = new();
    public ReactiveProperty<int> ItemAmount { get; } = new();

    public readonly InventorySlotModel SlotModel;

    public InventorySlotProxy(InventorySlotModel slotModel)
    {
        SlotModel = slotModel;

        ItemId.OnNext(slotModel.ItemId);
        ItemAmount.OnNext(slotModel.ItemAmount);

        ItemId.Skip(1).Subscribe(id => slotModel.ItemId = id);
        ItemAmount.Skip(1).Subscribe(amount => slotModel.ItemAmount = amount);
    }
}