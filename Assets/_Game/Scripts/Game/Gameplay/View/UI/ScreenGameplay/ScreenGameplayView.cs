using System;
using UnityEngine;
using UnityEngine.UI;

public class ScreenGameplayView : WindowView<ScreenGameplayViewModel>
{
    [SerializeField] private Button _openInventoryButton;

    private void Awake()
    {
        _openInventoryButton.onClick.AddListener(OnOpenInventoryButtonClick);
    }

    private void OnOpenInventoryButtonClick()
    {
        ViewModel.OpenInventory();

    }
}