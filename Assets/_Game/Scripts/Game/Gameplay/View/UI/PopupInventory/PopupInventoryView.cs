using R3;
using ObservableCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PopupInventoryView : PopupView<PopupInventoryViewModel>
{
    [SerializeField] InventorySlotView _slotPrefab;

    private readonly List<InventorySlotView> _slots = new();
    private PopupInventoryViewModel _viewModel;

    public void Bind(PopupInventoryViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel.SlotViewModels.ForEach(slotViewModel => CreateSlotView(slotViewModel));

        _viewModel.SlotViewModels.ObserveAdd().Subscribe(slotViewModel => CreateSlotView(slotViewModel.Value));
        _viewModel.SlotViewModels.ObserveRemove().Subscribe(slotViewModel => DeleteSlotView(slotViewModel.Value));
    }

    private void CreateSlotView(InventorySlotViewModel slotViewModel)
    {
        var slotView = Instantiate(_slotPrefab);
        slotView.Bind(slotViewModel);
        _slots.Add(slotView);
    }

    private void DeleteSlotView(InventorySlotViewModel slotViewModel)
    {
        // Не нужны проверки на null, т.к. есть гарантия, что
        // если существует viewModel, то и существует view слота
        var slotView = _slots.First(slotView => slotViewModel == slotView.ViewModel);
        _slots.Remove(slotView);
    }
}