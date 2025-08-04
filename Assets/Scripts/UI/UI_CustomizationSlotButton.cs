using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_CustomizationSlotButton : UI_ItemDisplaySlot
    {
        [SerializeField] Button button;
        UI_CharacterCustomization customizationContainer => container as UI_CharacterCustomization;

        public override void Reset()
        {
            base.Reset();
        }

        public void Button_EquipPreviewModel() 
        {
            if(Parameters != null)
                customizationContainer.EquipPreview(Parameters as EquipmentParameters);
        }
    }
}
