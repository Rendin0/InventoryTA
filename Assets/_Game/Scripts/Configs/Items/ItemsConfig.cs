using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsConfig", menuName = "Configs/Items/Items Config")]
public class ItemsConfig : ScriptableObject
{
    public List<ItemConfig> ItemConfigs;
}