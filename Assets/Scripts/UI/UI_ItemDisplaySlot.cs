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

        public virtual void Setup(ItemParameters.ItemData Data, UI_ContainerBase container) 
        {
            if (Data == null) 
            {
                this.container = container;
                Reset();
                return;
            }

            this.Data = Data;
            icon.sprite = Data.Parameters.DisplayIcon;
            icon.enabled = true;
            this.container = container;
        }

        public virtual void Reset()
        {
            icon.sprite = null;
            icon.enabled = false;
            Data = null;
        }

    }
}
