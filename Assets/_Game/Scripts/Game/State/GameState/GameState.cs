
using System;

[Serializable]
public class GameState
{
    // Если нужно сделать поддержку нескольких инвентарей, можно
    // Добавить глобальный ID для них и хранить их в List<InventoryModel>
    public InventoryModel InventoryModel;
}