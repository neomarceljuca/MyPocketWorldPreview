using mpw.InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_CharacterCustomization : MonoBehaviour
    {
        #region References
        public GridLayoutGroup mainGridDisplay;
        public List<ItemParameters.ItemData> data;
        public List<UI_ItemDisplaySlot> displayedItemSlots;

        public ItemGroup test_LoadItems;

        #endregion

        #region Behavior
        private void OnEnable()
        {
            //displayedItemSlots = new();
            data = test_LoadItems.Items.Select(x=> new ItemParameters.ItemData(x)).ToList();

            foreach (var slot in displayedItemSlots) 
            {
                slot.Reset();
            }
            for(int i = 0; i < data.Count; i++)
            {
                displayedItemSlots[i].Setup(data[i].Parameters);
            }
        }

        private void OnDisable()
        {

        }
        #endregion
    }
}
