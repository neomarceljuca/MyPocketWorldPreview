using UnityEngine;

namespace mpw.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        protected ItemParameters.ItemData[] data;

        public ItemParameters.ItemData[] Data => data;
    }
}
