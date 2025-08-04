using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using mpw.InventorySystem;

namespace mpw.Utils
{
    [CreateAssetMenu(fileName = "MPWResources", menuName = "mpw/Utils/Resources")]
    public class MpwResources : SerializedScriptableObject
    {
        [SerializeField] Dictionary<EquipmentCategory, Sprite> defaultIconPerSocket = new();

        public Sprite GetSocketSprite(EquipmentCategory category) => defaultIconPerSocket[category];
    }
}
