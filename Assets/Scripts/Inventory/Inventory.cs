using System.Linq;
using UnityEngine;

namespace mpw.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        protected ItemParameters.ItemData[] data;

        public ItemParameters.ItemData[] Data => data;

        public void Innit(ItemGroup items) 
        {
            data = items.Items.Select(x => x.DefaultItemData).ToArray();
        }
    }
}
