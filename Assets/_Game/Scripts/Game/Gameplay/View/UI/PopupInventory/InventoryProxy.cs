
using ObservableCollections;
using R3;

public class InventoryProxy
{
    public ObservableList<InventorySlotProxy> InventorySlotProxies { get; } = new();

    public InventoryProxy(InventoryModel inventoryModel)
    {
        inventoryModel.InventorySlots.ForEach(slot => InventorySlotProxies.Add(new(slot)));

        InventorySlotProxies.ObserveAdd().Subscribe(slot => inventoryModel.InventorySlots.Add(slot.Value.SlotModel));
        InventorySlotProxies.ObserveRemove().Subscribe(slot => inventoryModel.InventorySlots.Remove(slot.Value.SlotModel));
    }


}