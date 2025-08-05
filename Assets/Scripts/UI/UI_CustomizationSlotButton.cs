using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_CustomizationSlotButton : UI_ItemDisplaySlot
    {
        [SerializeField] Toggle toggle;
        public Image equippedIcon;
        UI_CharacterCustomization customizationContainer => container as UI_CharacterCustomization;

        public override void Reset()
        {
            base.Reset();
            toggle.interactable = false;
            toggle.isOn = false;
            toggle.onValueChanged.RemoveAllListeners();
        }
        public void Setup(ItemParameters.ItemData data, UI_ContainerBase container, Entity.Entity overrideEntity)
        {
            toggle.isOn = overrideEntity.Equipment.isEquipping(data as EquipmentParameters.EquipmentData);
            toggle.interactable = true;
            //equippedIcon.gameObject.SetActive(overrideEntity.Equipment.isEquipping(data as EquipmentParameters.EquipmentData));
            Setup(data, container);

            toggle.onValueChanged.AddListener((isOn) => {
                if (isOn) 
                {
                    customizationContainer.EquipPreview(Data as EquipmentParameters.EquipmentData);
                }
            });
        }


    }
}
