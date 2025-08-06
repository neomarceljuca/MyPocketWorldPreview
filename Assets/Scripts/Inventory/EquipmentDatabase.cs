using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace mpw.InventorySystem
{
    [CreateAssetMenu(menuName = "mpw/Inventory/EquipmentDatabase")]
    public class EquipmentDatabase : ScriptableObject
    {
        public List<EquipmentParameters> allEquipment = new();

        public EquipmentParameters GetByID(int id)
        {
            if (id >= 0 && id < allEquipment.Count)
                return allEquipment[id];
            return null;
        }

        public int GetID(EquipmentParameters equipment)
        {
            return allEquipment.IndexOf(equipment);
        }

        [Button]
        public void Refresh()
        {
            string[] guids = AssetDatabase.FindAssets($"t:{typeof(EquipmentParameters).Name}");
            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                EquipmentParameters asset = AssetDatabase.LoadAssetAtPath<EquipmentParameters>(path);
                if (allEquipment != null && !allEquipment.Contains(asset))
                    allEquipment.Add(asset);
            }
        }
    }
}
