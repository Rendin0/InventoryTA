
using R3;

public class InventorySlotViewModel
{
    public ReactiveProperty<string> IconPath { get; } = new();
    public ReactiveProperty<string> ItemAmount { get; } = new();

    public readonly InventorySlotProxy SlotProxy;

    public InventorySlotViewModel(InventorySlotProxy slotProxy)
    {
        SlotProxy = slotProxy;

        SlotProxy.ItemId.Subscribe(id => IconPath.OnNext($"UI/Items/{id}"));

        // Если кол-во предмета в слоте 1 или меньше, то скрываем текст для красоты
        SlotProxy.ItemAmount.Subscribe(amount => ItemAmount.OnNext(amount < 2 ? "" : amount.ToString()));
    }
}