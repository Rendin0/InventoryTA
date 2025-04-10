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
        transform.localScale = Vector3.one;
        ViewModel = viewModel;

        ViewModel.IconPath.Subscribe(path => ChangeIcon(path));

        ViewModel.ItemAmount.Subscribe(amount => _itemAmountText.text = amount);
    }

    private void ChangeIcon(string path)
    {
        if (_itemIcon == null)
            return;

        _itemIcon.sprite = Resources.Load<Sprite>(path);
        if (_itemIcon.sprite == null)
            _itemIcon.color = Color.clear;
        else
            _itemIcon.color = Color.white;
    }
}