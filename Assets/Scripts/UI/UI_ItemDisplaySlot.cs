using mpw.InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace mpw.UI
{
    public class UI_ItemDisplaySlot : MonoBehaviour
    {
        public ItemParameters parameters;
        public Image icon;

        private void OnEnable()
        { 
        }

        public void Setup(ItemParameters parameters) 
        {
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
