using R3;
using ObservableCollections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupInventoryView : PopupView<PopupInventoryViewModel>
{
    [SerializeField] private InventorySlotView _slotPrefab;
    [SerializeField] private Transform _slotsContainer;

    [SerializeField] private Button _addItemButton;
    [SerializeField] private Button _removeItemButton;
    [SerializeField] private Button _addSlotButton;
    [SerializeField] private Button _removeSlotButton;

    [SerializeField] private TMP_InputField _itemIdInputField;

    private readonly List<InventorySlotView> _slots = new();
    private PopupInventoryViewModel _viewModel;


    private void OnEnable()
    {
        _addItemButton.onClick.AddListener(OnAddItemButtonClick);
        _removeItemButton.onClick.AddListener(OnRemoveItemButtonClick);
        _addSlotButton.onClick.AddListener(OnAddSlotButtonClick);
        _removeSlotButton.onClick.AddListener(OnRemoveSlotButtonClick);
    }

    #region Data Binding
    protected override void OnBind(PopupInventoryViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel.SlotViewModels.ForEach(slotViewModel => CreateSlotView(slotViewModel));

        _viewModel.SlotViewModels.ObserveAdd().Subscribe(slotViewModel => CreateSlotView(slotViewModel.Value));
        _viewModel.SlotViewModels.ObserveRemove().Subscribe(slotViewModel => DeleteSlotView(slotViewModel.Value));
    }

    private void CreateSlotView(InventorySlotViewModel slotViewModel)
    {
        var slotView = Instantiate(_slotPrefab);
        slotView.transform.SetParent(_slotsContainer);
        slotView.Bind(slotViewModel);
        _slots.Add(slotView);
    }
    private void DeleteSlotView(InventorySlotViewModel slotViewModel)
    {
        // Не нужны проверки на null, т.к. есть гарантия, что
        // если существует viewModel, то и существует view слота
        var slotView = _slots.First(slotView => slotViewModel == slotView.ViewModel);
        _slots.Remove(slotView);
        Destroy(slotView.gameObject);
    }
    #endregion

    #region ButtonCallbacks
    private void OnAddItemButtonClick()
    {
        _viewModel.AddItem(_itemIdInputField.text);
    }
    private void OnRemoveItemButtonClick()
    {
        _viewModel.RemoveItem(_itemIdInputField.text);
    }
    private void OnAddSlotButtonClick()
    {
        _viewModel.AddSlot();
    }
    private void OnRemoveSlotButtonClick()
    {
        _viewModel.RemoveSlot();
    }
    #endregion
}