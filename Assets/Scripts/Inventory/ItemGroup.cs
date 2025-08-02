using mpw.InventorySystem;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemGroup_", menuName = "mpw/Inventory/ItemGroup")]
public class ItemGroup : SerializedScriptableObject
{
    [SerializeField] private List<ItemParameters> items = new();
    public List<ItemParameters> Items => items;
}
