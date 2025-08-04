using mpw.InventorySystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_CharacterCustomization : UI_ContainerBase
    {
        #region References
        public GridLayoutGroup mainGridDisplay;
        public List<ItemParameters.ItemData> data;
        public List<UI_ItemDisplaySlot> displayedItemSlots;
        public Entity.Entity previewCharacter;

        public ItemGroup test_LoadItems;

        #endregion
        #region Behavior

        public override void Show() 
        { 
            data = test_LoadItems.Items.Select(x => new ItemParameters.ItemData(x)).ToList();
            foreach (var slot in displayedItemSlots)
            {
                slot.Reset();
            }
            for (int i = 0; i < data.Count; i++)
            {
                displayedItemSlots[i].Setup(data[i].Parameters, this);
            }
            SetupPreview();
            base.Show();
        }
        #endregion
        public void SetupPreview()
        {
            previewCharacter.Equipment.CopyLoadout(MPWApp.Instance.LocalPlayer.Equipment);
        }

        public void EquipPreview(EquipmentParameters parameters) 
        {
            previewCharacter.Equipment.EquipItem(parameters);
        }

        #region External
        public void Button_Close() => MPWApp.Instance.UIManager.ToggleUI("");

        public void Button_SaveChanges() 
        {
            MPWApp.Instance.LocalPlayer.Equipment.CopyLoadout(previewCharacter.Equipment);
            Button_Close();
        } 
        #endregion
    }
}
