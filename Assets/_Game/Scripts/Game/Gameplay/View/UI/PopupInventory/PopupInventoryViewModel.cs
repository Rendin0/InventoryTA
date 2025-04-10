
using ObservableCollections;
using R3;
using System.Linq;

public class PopupInventoryViewModel : WindowViewModel
{
    public override string Id => "PopupInventory";
    public ObservableList<InventorySlotViewModel> SlotViewModels { get; } = new();

    private readonly InventoryProxy _inventoryProxy;
    private readonly InventoryService _inventoryService;

    #region Data Binding
    public PopupInventoryViewModel(InventoryProxy inventoryProxy, InventoryService inventoryService)
    {
        _inventoryProxy = inventoryProxy;
        _inventoryService = inventoryService;

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
        // Не нужны проверки на null, т.к. есть гарантия, что
        // если существует прокси слота, то и существует viewModel слота
        var slotViewModel = SlotViewModels.First(slot => slotProxy == slot.SlotProxy);
        SlotViewModels.Remove(slotViewModel);
    }
    #endregion

    #region Button Callbacks
    public void AddItem(string ItemId)
    {
        _inventoryService.AddItem(ItemId);
    }

    public void RemoveItem(string ItemId)
    {
        _inventoryService.RemoveItem(ItemId);
    }

    public void AddSlot()
    {
        _inventoryService.AddSlot();
    }

    public void RemoveSlot()
    {
        _inventoryService.RemoveSlot();
    }

    #endregion

}