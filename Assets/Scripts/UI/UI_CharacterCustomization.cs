using mpw.InventorySystem;
using Sirenix.OdinInspector;
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
        public List<EquipmentParameters.EquipmentData> data;
        public List<UI_CustomizationSlotButton> displayedItemSlots;
        [SerializeField] private ToggleGroup categoryToggleGroup;
        public Toggle categoryStartingToggle;
        public Entity.Entity previewCharacter;

        private Entity.Entity playerEntity => MPWApp.Instance.LocalPlayer;
        private List<EquipmentParameters.EquipmentData> filteredData;
        #endregion

        #region Behavior
        public override void Show()
        {
            LoadPlayerEquipment();
            foreach (var toggle in categoryToggleGroup.GetComponentsInChildren<Toggle>())
            {
                toggle.isOn = false;
            }
            categoryStartingToggle.isOn = true; //Selects 'all' categories & sets up slots
            SetupPreview();
            base.Show();
        }
        #endregion

        #region Utilities
        private void SetupSlots() 
        {
            foreach (var slot in displayedItemSlots)
            {
                slot.Reset();
            }
            for (int i = 0; i < filteredData.Count; i++)
            {
                displayedItemSlots[i].Setup(filteredData[i], this, previewCharacter);
            }
        }
        private void LoadPlayerEquipment() 
        {
            List<EquipmentParameters.EquipmentData> totalData = new();
            totalData.AddRange(playerEntity.Equipment.Equipped.Select(x => x.Value).ToList());
            totalData.AddRange(playerEntity.References.Inventory.Data.Select(x => x as EquipmentParameters.EquipmentData).ToList());
            data = totalData;
        }

        public void SetupPreview()
        {
            if(playerEntity != null)
                previewCharacter.Equipment.CopyLoadout(playerEntity.Equipment);
        }

        public void EquipPreview(EquipmentParameters.EquipmentData data) 
        {
            previewCharacter.Equipment.EquipItem(data);
        }

        public void PaintEquipment(EquipmentParameters.EquipmentData data, Color color) 
        {
            data.ColorData = color;
            EquipPreview(data);
        }

        private void Internal_FilterByCategory(EquipmentCategory category) 
        {
            if (category == EquipmentCategory.All) filteredData = data;
            else
                filteredData = data.Where(x => x.Parameters.Category == category).ToList();
        }
        #endregion

        #region External
        public void Button_Close() => MPWApp.Instance.UIManager.ToggleUI("CC");

        public void Button_SaveChanges() 
        {
            if (playerEntity != null) UpdateInventory();
            Button_Close();
        }

        public void UpdateInventory() 
        {
            foreach(var item in previewCharacter.Equipment.Equipped.Select(x => x.Value)) 
            {
                if(data.Contains(item)) data.Remove(item);
            }
            playerEntity.Equipment.CopyLoadout(previewCharacter.Equipment);
            playerEntity.References.Inventory.InnitData(data.ToArray());
        }

        public void FilterByCategory(EquipmentCategory category)
        {
            Internal_FilterByCategory(category);
            SetupSlots();
        }
        #endregion
    }
}
