using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemAmountText;

    public InventorySlotViewModel ViewModel;

    public void Bind(InventorySlotViewModel viewModel)
    {
        ViewModel = viewModel;

        ViewModel.IconPath.Subscribe(path => _itemIcon.sprite = Resources.Load<Sprite>(path));

        ViewModel.ItemAmount.Subscribe(amount => _itemAmountText.text = amount);
    }
}