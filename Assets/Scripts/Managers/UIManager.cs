using UnityEngine;
using UnityEngine.UI;
namespace mpw.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas mainCanvas;
        [SerializeField] Transform tooltipHolder;
        [SerializeField] GameObject tooltipBaseObject;
        
        private UI_Tooltip tooltipInstance;

        public Canvas MainCanvas;

        public void ShowTooltip(string message)
        {
            if (tooltipInstance == null) 
            {
                tooltipInstance = Instantiate(tooltipBaseObject, tooltipHolder).GetComponent<UI_Tooltip>();
            }
            tooltipInstance.SetTexts(message);

            LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipInstance.transform as RectTransform);
            tooltipInstance.gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            tooltipInstance.gameObject.SetActive(false);
        }

    }
}