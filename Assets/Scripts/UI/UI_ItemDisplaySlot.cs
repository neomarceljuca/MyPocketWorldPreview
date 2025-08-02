using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_ItemDisplaySlot : UI_ItemObject
    {
        public Image icon;

        private void OnEnable()
        { 
        }

        public void Setup(ItemParameters parameters) 
        {
            this.Parameters = parameters;
            icon.sprite = parameters.Icon;
            icon.enabled = true;
        }

        public void Reset()
        {
            icon.sprite = null;
            icon.enabled = false;
        }

    }
}
