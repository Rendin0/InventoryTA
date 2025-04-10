
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfig_", menuName = "Configs/Items/Item Config")]
public class ItemConfig : ScriptableObject
{
    public string ItemId;
    [Min(1)] public int ItemMaxStack;
    public ItemTypes ItemType;
}