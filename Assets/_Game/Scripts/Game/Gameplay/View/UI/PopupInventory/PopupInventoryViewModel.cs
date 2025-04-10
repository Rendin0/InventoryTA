
using ObservableCollections;
using R3;
using System.Linq;

public class PopupInventoryViewModel : WindowViewModel
{
    public override string Id => "PopupInventory";
    public ObservableList<InventorySlotViewModel> SlotViewModels { get; } = new();

    private readonly InventoryProxy _inventoryProxy;

    public PopupInventoryViewModel(InventoryProxy inventoryProxy)
    {
        _inventoryProxy = inventoryProxy;

        _inventoryProxy.InventorySlotProxies.ForEach(slotProxy => CreateSlotViewModel(slotProxy));

        _inventoryProxy.InventorySlotProxies.ObserveAdd().Subscribe(slotProxy => CreateSlotViewModel(slotProxy.Value));
        _inventoryProxy.InventorySlotProxies.ObserveRemove().Subscribe(slotProxy => DeleteSlotViewModel(slotProxy.Value));
    }

    private void CreateSlotViewModel(InventorySlotProxy slotProxy)
    {
        SlotViewModels.Add(new(slotProxy));
    }

    private void DeleteSlotViewModel(InventorySlotProxy slotProxy)
    {
        // �� ����� �������� �� null, �.�. ���� ��������, ���
        // ���� ���������� ������ �����, �� � ���������� viewModel �����
        var slotViewModel = SlotViewModels.First(slot => slotProxy == slot.SlotProxy);
        SlotViewModels.Remove(slotViewModel);
    }

}