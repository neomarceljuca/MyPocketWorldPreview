using System.Linq;
using UnityEngine;

namespace mpw.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        private float startingBallance;
        protected ItemParameters.ItemData[] data;
        private float currentBalance;

        public ItemParameters.ItemData[] Data => data;
        public float CurrentBalance
            {
                get { return currentBalance; }
                set { currentBalance = value; }
            }
        private void Start()
        {
            currentBalance = startingBallance;
        }

        public void InnitData(ItemGroup items, float balance = 0) 
        {
            data = items.Items.Select(x => x.DefaultItemData).ToArray();
        }
    }
}
