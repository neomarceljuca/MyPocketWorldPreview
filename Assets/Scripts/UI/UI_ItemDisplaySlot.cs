using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_ItemDisplaySlot : UI_ItemObject
    {
        public UI_ContainerBase container;
        public Image icon;

        public virtual void Setup(ItemParameters parameters, UI_ContainerBase container) 
        {
            this.Parameters = parameters;
            icon.sprite = parameters.DisplayIcon;
            icon.enabled = true;
            this.container = container;
        }

        public virtual void Reset()
        {
            icon.sprite = null;
            icon.enabled = false;
            Parameters = null;
        }

    }
}
